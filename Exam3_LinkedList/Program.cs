using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Insert(0, "lolz");
            list.Insert(2, "this is the new third");
            list.Delete(1);
            list.Delete(3);
            list.Traverse();

            Console.WriteLine(list.Total);
            
        }
    }
}
