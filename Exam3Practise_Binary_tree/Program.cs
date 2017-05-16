using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3Practise_Binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            Random gen = new Random();
            int[] tenInts = new int[10];
            for (int i = 0; i < tenInts.Length; i++)
            {
                tenInts[i] = gen.Next(1, 101);
            }
            foreach (var item in tenInts)
            {
                tree.Insert(item);
            }
            tree.Print();
        }
    }
}
