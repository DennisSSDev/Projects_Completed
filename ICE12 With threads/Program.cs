using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ICE12_With_threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] newArray = new Thread[3];
            Child newBorn1 = new Child("Alessandro", "I suck at artwork!");
            Child newBorn2 = new Child("Anthony", "I want my fighting game");
            Child newBorn3 = new Child("Kat", "Where is my TA money");
            newArray[0] = new Thread(newBorn1.Whine);
            newArray[1] = new Thread(newBorn2.Whine);
            newArray[2] = new Thread(newBorn3.Whine);

            for (int i = 0; i < newArray.Length; i++)
            {
                
                newArray[i].Start();
                
                newArray[i].Join();
               
            }
            Console.WriteLine("Knock it off");
        }
    }
}
