using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_YaY
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedList = new int[10];
            Random randomNumberGen = new Random();
           for(int i = 0; i<unsortedList.Length; i++)
            {
                unsortedList[i] = randomNumberGen.Next(0, 10001);
            }
            List<int> sortedList = new List<int>();
            sortedList.Add(unsortedList[0]);
            
            for (int i = 1; i < unsortedList.Length; i++)
            {
                int temp = unsortedList[i];
                int j = 0;
                for (j = i; j > 0 && temp < unsortedList[j-1]; j--)
                {
                    unsortedList[j] = unsortedList[j - 1];
                }
                unsortedList[j] = temp;
            }
            foreach (var item in unsortedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
