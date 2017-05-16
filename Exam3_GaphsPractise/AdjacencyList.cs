using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3_GaphsPractise
{
    class AdjacencyList
    {
        Vertex one;
        Vertex two;
        Vertex three;
        Vertex four;
        Vertex five;
        int[,] matrix = new int[5, 5];
        List<string> general = new List<string>();
        Dictionary<string, List<string>> membersAndConnections = new Dictionary<string, List<string>>();

        Dictionary<String, Vertex> verticies = new Dictionary<string, Vertex>();
        List<Vertex> vertList = new List<Vertex>();
        public AdjacencyList()
        {
            one = new Vertex() { Name = "My Room", Visited = false };
            two = new Vertex() { Name = "Classroom", Visited = false };
            three = new Vertex() { Name = "Dorm", Visited = false };
            four = new Vertex() { Name = "Outside World", Visited = false };
            five = new Vertex() { Name = "Dank Memes", Visited = false};

            List<string> one1 = new List<string>();
            List<string> two2 = new List<string>();
            List<string> three3 = new List<string>();
            List<string> four4 = new List<string>();
            List<string> five5 = new List<string>();

            general.Add(one.Name);
            general.Add(two.Name);
            general.Add(three.Name);
            general.Add(four.Name);
            general.Add(five.Name);


            one1.Add(five.Name);
            one1.Add(three.Name);

            two2.Add(four.Name);

            three3.Add(one.Name);
            three3.Add(four.Name);

            four4.Add(two.Name);
            four4.Add(three.Name);

            five5.Add(one.Name);


            matrix[0, 0] = 0;
            matrix[0, 1] = 0;
            matrix[0, 2] = 1;
            matrix[0, 3] = 0;
            matrix[0, 4] = 1;

            matrix[1, 0] = 0;
            matrix[1, 1] = 0;
            matrix[1, 2] = 0;
            matrix[1, 3] = 1;
            matrix[1, 4] = 0;

            matrix[2, 0] = 1;
            matrix[2, 1] = 0;
            matrix[2, 2] = 0;
            matrix[2, 3] = 1;
            matrix[2, 4] = 0;

            matrix[3, 0] = 0;
            matrix[3, 1]= 1;
            matrix[3, 2]= 1;
            matrix[3, 3]= 0;
            matrix[3, 4]= 0;

            matrix[4, 0] = 1;
            matrix[4, 1]= 0;
            matrix[4, 2]= 0;
            matrix[4, 3]= 0;
            matrix[4, 4]= 0;
             


            membersAndConnections.Add(one.Name, one1);
            membersAndConnections.Add(two.Name, two2);
            membersAndConnections.Add(three.Name, three3);
            membersAndConnections.Add(four.Name, four4);
            membersAndConnections.Add(five.Name, five5);
            //Searching 
            vertList.Add(one);
            vertList.Add(two);
            vertList.Add(three);
            vertList.Add(four);
            vertList.Add(five);

            verticies.Add("My Room", one);
            verticies.Add("Classroom", two);
            verticies.Add("Dorm", three);
            verticies.Add("Outside World", four);
            verticies.Add("Dank Memes", five);


        }

        public void Reset()
        {
            foreach (var item in vertList)
            {
                item.Visited = false;
            }
        }

        public Vertex GetUnvisited(String name)
        {
            int count = 0;
            if (verticies.ContainsKey(name))
            {
                foreach (var item in vertList)
                {
                    if(item.Name == name)
                    {
                        break;
                    }
                    count++;
                }
                for (int i = 0; i < 5; i++)
                {
                    if(matrix[count,i] == 1 && vertList[i].Visited == false)
                    {
                        return vertList[i];
                    }
                }
            }
            
            return null;
        }
        public void DepthFirst(String name)
        {
            if (verticies.ContainsKey(name))
            {
                Reset();
                Stack<Vertex> stack = new Stack<Vertex>();
                Console.WriteLine(name);
                stack.Push(verticies[name]);
                verticies[name].Visited = true;
                while (stack.Count != 0)
                {
                    Vertex temp = GetUnvisited(stack.Peek().Name);
                    if (temp == null)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine(temp.Name);
                        stack.Push(temp);
                        temp.Visited = true;
                    }
                }
            }
        }
        public List<string> GetAdjList(string room)
        {
            if (membersAndConnections.ContainsKey(room))
            {
                return membersAndConnections[room];
            }
            else
            {
                return null;//make sure to have an exception for a null at the program stage
            }
        }

        public List<string> GetAdjList1(string room)
        {
            List<string> someList = new List<string>();
            int count = 0;
            if (general.Contains(room))
            {
                count = general.IndexOf(room);
                for (int i = 0; i < 5; i++)
                {
                    if(matrix[count, i] == 1)
                    {
                        someList.Add(general[i]);
                    }
                }
                return someList;
           }
            else
            {
                return null;
            }
        }
        public bool IsConnected2(String room1, String room2)
        {
            if (general.Contains(room1))
            {
                if (general.Contains(room2))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (matrix[general.IndexOf(room1), i] == 1 && general[i] == room2)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }
        public bool IsConnected(string room1, string room2)
        {
            if (membersAndConnections.ContainsKey(room1))
            {
                if (membersAndConnections[room1].Contains(room2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
