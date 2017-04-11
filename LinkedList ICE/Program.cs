using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_ICE
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList villans = new LinkedList();
            villans.Add("Riddler");
            villans.Add("Joker");
            villans.Add("Mr Freeze");
            villans.Add("catwoman");
            villans.Add("Poison Ivy");
            villans.Insert(0, "Mr.Strange");
            villans.Traverse();

            Console.WriteLine("\n" + villans.GetData(1));
        }
    }
}
