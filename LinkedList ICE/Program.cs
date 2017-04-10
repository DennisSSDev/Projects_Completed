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



            villans.Traverse();

        }
    }
}
