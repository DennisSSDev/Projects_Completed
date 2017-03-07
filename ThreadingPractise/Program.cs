using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] newThreadArray = new Thread[100];

            for (int i = 0; i < newThreadArray.Length; i++)
            {
                Number a = new Number(i);
                Thread b = new Thread(a.Print);
                newThreadArray[i] = b;
                b.Start();
            }
            

        }
    }
}
