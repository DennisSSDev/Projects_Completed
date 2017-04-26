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
            string commander = null;

            Console.WriteLine("Testing123");
            while (commander != "quit")
            {
                
                string temp = Console.ReadLine();
                commander = temp;
                switch (commander)
                {
                    case "q":
                        commander = "quit";
                        break;
                    case "print":
                        for (int i = 0; i <= listOfNodes.Count; i++)
                        {
                            Console.WriteLine(listOfNodes.GetElement(i));
                        }
                        break;
                    case "count":
                        Console.WriteLine(listOfNodes.Count);
                        break;
                    case "clear":
                        listOfNodes.Clear();
                        break;
                    case "remove"://look at linked lisk code first
                        Random ranRemoval = new Random();

                        listOfNodes.Remove(ranRemoval.Next(0,listOfNodes.Count));
                        break;
                    case "scramble"://look at the linked list code first
                        Random ran = new Random();
                        Node storedNode = new Node(listOfNodes.Remove(ran.Next(0, listOfNodes.Count+1)));
                        listOfNodes.Insert(storedNode.Data, ran.Next(0, listOfNodes.Count + 1));
                        break;


                    default:
                        listOfNodes.Add(commander);
                        break;
                }
            }
        }
    }
}
