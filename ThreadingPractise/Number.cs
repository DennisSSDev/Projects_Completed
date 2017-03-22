using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingPractise
{
    class Number
    {
        private int num;

        public Number(int someNum)
        {
            num = someNum;
        }

        public void Print()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.Write(num);
            }
        }
    }
}
