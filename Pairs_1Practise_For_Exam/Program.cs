using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Pairs_1Practise_For_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            //List for numbers read in 
            int count = 0;
            int diff = 0;
            //Open the file
            using (StreamReader sr = new StreamReader("small_file.txt"))
            {
                string firstLine = sr.ReadLine();
                var data = firstLine.Split(' ');
                int forNumberOfItems = 0;
                int.TryParse(data[0], out forNumberOfItems);
                diff = Convert.ToInt32(data[1]);
                string file = sr.ReadToEnd();
                var nums = file.Split(' ');
                foreach (var item in nums)
                {
                    numbers.Add(Convert.ToInt32(item));
                }
            }
            DateTime start = DateTime.Now;
            numbers.Sort();
            for(int i = 0; i<numbers.Count; i++)
            {
                for(int j = 1; j < numbers.Count; j++)
                {
                    if((numbers[j] - numbers[i]) == diff)
                    {
                        count++;
                    }
                    if(numbers[j] - numbers[i] > diff)
                    {
                        break;
                    }
                }
            }

            //count of the pairs
            //read the first line
            //parse the data from the first line 
            //read the rest the file
            //close the file
            //find the pairs
            //print out the pairs
            Console.WriteLine("Num of pairs" + count);
            Console.WriteLine("it took" + (DateTime.Now - start));
        }
    }
}
