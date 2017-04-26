using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkGame_ICE_for_graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyList someList = new AdjacencyList();
            bool won = false;
            string startingRoom = "Alessandro's shitty room";
            string temp = null;
            string storage = null;
            while (won != true)
            {
                storage = null;
                foreach (var item in someList.GetAdjacentList(startingRoom))
                {
                    storage += item + ", ";
                }
                Console.WriteLine("You are currently in the: " + startingRoom);
                Console.WriteLine("Nearby are: " + storage);
                Console.WriteLine("Where would you like to go? ");
                temp = Console.ReadLine();
                if(someList.IsConnected(temp, startingRoom))
                {
                    startingRoom = temp;
                }
                else
                {
                    Console.WriteLine("sry, that's not a valid room");
                }
                if(startingRoom == "Steve's Office")
                {
                    won = true;
                    Console.WriteLine("You have reached your destination");
                }
            }
        }
    }
}
