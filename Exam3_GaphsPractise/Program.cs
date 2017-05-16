using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3_GaphsPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyList list = new AdjacencyList();
            string reader = null;
            string starting_room = "Classroom";
            /*Console.WriteLine("Hi, let's get those dank memes!\nYou are starting from your" +
                "\nBoring classrom.\nQuickly find a way to get to the memes here are your options...");
            while(starting_room != "Dank Memes")
            {
                Console.WriteLine("the connected doors are: \n");
                foreach (var item in list.GetAdjList1(starting_room))
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine("\nwhere would you like to go?");
                reader = Console.ReadLine();
                if (list.IsConnected2(starting_room, reader))
                {
                    starting_room = reader;
                }
                else
                {
                    Console.WriteLine("this room doesn't exist from your location");
                }
            }
            Console.WriteLine("!!!\nCongratz\n!!!\nYou found the sacred, have fun.");*/
            list.DepthFirst(starting_room);
        }
    }
}
