using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Names> dictionary = new Dictionary<string, Names>();
            dictionary.Add("Dennis", new Names { Description = "A nice guy who wants to leave a mark on this land" });
            dictionary.Add("Ronald", new Names { Description = "Sometimes an annoying fag who needs to learn to live alone" });
            string exit = "";
            while(exit != "exit")
            {
                Console.WriteLine("Welcome to our library of descritions, who would you like to look for?");
                exit = Console.ReadLine();
                if (dictionary.ContainsKey(exit))
                {
                    Console.WriteLine(dictionary[exit]);
                }
                else if(exit == "exit")
                {
                    break;
                }
                else if (exit == "list")
                {
                    foreach(string key in dictionary.Keys)
                    {
                        Console.WriteLine(key);
                    }
                }
                else
                {
                    Console.WriteLine("The given key does not match with any existing keys, please try again");
                }
            }
        }
    }
}
