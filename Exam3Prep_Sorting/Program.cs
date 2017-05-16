using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3Prep_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[50000];
            Random ran = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ran.Next(0, 1001);
            }

            for (int i = 1; i < 50000; i++)
            {
                int temp = array[i];//save the member at i
                int last = i;
                for (int j = i; j > 0 && temp<array[j-1]; j--)
                {
                    array[j] = array[j - 1];
                    last = j;
                }
                array[last - 1] = temp;
            }

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

        }
    }
}
