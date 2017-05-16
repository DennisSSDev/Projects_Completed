using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Exam3_Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            Dictionary<string, bool> wordsAgain = new Dictionary<string, bool>();
            using (StreamReader reader = new StreamReader("dictionary.txt"))
            {
                while(reader.ReadLine() != null)
                {
                    string table = reader.ReadLine();
                    words.Add(table);
                    wordsAgain.Add(table, false);
                }
            }
            foreach (var item in words)
            {
                if(words.Contains(item+item))
                {
                    Console.WriteLine(item);
                }
            }
            foreach (var item in wordsAgain)
            {
                string itemst = item.Key + item.Key;
                if (wordsAgain.ContainsKey(itemst))
                {
                    Console.WriteLine(itemst);
                }
            }



        }
    }
}
