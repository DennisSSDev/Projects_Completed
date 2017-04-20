using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Tree_practise
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            int[] newArray = new int[10];
            for (int i = 0; i < 10; i++)
            {
                
                newArray[i] = generator.Next(0, 101);

            }
            Tree tree = new Tree();
            for (int i = 0; i < 10; i++)
            {
                tree.Insert(newArray[i]);
            }

            tree.Print();
            

        }
    }
}
