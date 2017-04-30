using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList listOfNodes = new LinkedList();
            string commander = null;//value that will read input
            Random ranRemoval = new Random();//randomizer
            Random ran = new Random();//randomizer
            Console.WriteLine("Testing123");//Greeting message
            while (commander != "quit")//until you decide to stop, do the following 
            {
                
                string temp = Console.ReadLine();
                commander = temp;
                switch (commander)
                {
                    case "q":
                        commander = "quit";
                        break;
                    case "print":
                        for (int i = 0; i < listOfNodes.Count; i++)
                        {
                            Console.WriteLine(listOfNodes.GetElement(i));
                        }
                        break;
                    case "count"://gives the total count of the members in the linked list
                        Console.WriteLine("the total count of nodes is: " + listOfNodes.Count);
                        break;
                    case "clear"://cleares the list
                        Console.WriteLine("The list is cleared");
                        listOfNodes.Clear();
                        break;
                    case "remove"://look at linked lisk code first
                        string removed = listOfNodes.Remove(ranRemoval.Next(0,listOfNodes.Count));//randomly remove a member of the list
                        Console.WriteLine(removed + " has been removed from the list"); 
                        break;
                    case "scramble"://look at the linked list code first (will first remove a member of the list and then put it back into the list
                        //at a random position
                        string storing = listOfNodes.Remove(ran.Next(0, listOfNodes.Count));
                        Console.WriteLine(storing + " has been scrambled");
                        Node storedNode = new Node(storing);
                        listOfNodes.Insert(storedNode.Data, ran.Next(0, listOfNodes.Count));
                        break;
                    default:
                        listOfNodes.Add(commander);//if none of the commands are met, add a member to the list 
                        Console.WriteLine(commander + " has been added to the list");
                        break;
                }
            }
        }
    }
}
