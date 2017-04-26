using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ICE_For_Hashing
{
    class Program
    {
        static void Main(string[] args)
        {

            Timer newTimer = new Timer();
            int maxReplay = 0;
            int maxDictRelay = 0;
            List<string> newListStrings = new List<string>();
            Dictionary<string, bool> newDict = new Dictionary<string, bool>();
            using (StreamReader textEater = new StreamReader("dictionary.txt"))
            {
                while(textEater.ReadLine() != null)
                {
                    string eater = textEater.ReadLine();
                    newListStrings.Add(eater);
                    newDict.Add(eater, false);
                }

            }
            newTimer.StartTimer();
           /* for (int i = 0; i <newListStrings.Count; i++)
            {
                string doubled = newListStrings[i] + newListStrings[i];
       
            if(newListStrings.Contains(doubled))
            {
               maxReplay++;
            }        
                
            }
            */
            

            foreach (string item in newDict.Keys)
            {
                string value = item + item;
                if (newDict.ContainsKey(value))
                {
                    newListStrings.Add(value);
                    Console.WriteLine(value);
                    maxDictRelay++;
                }
            }
            for (int i = 0; i < newListStrings.Count; i++)
            {
                newDict[newListStrings[i]] = true;
            }
            newTimer.StopTimer();
            Console.WriteLine(maxDictRelay + " " + newTimer.TotalTIme);
            
        }
    }
}
