using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ICE12_With_threads
{
    class Child
    {
        public string Name { get; set; }
        public string Saying { get; set; }
        public Child(string pName, string pSay)
        {
            Name = pName;
            Saying = pSay;
        }
        public void Whine()
        {
            for (int i = 0; i < 5; i++)
            {
                
                Console.WriteLine(Name + ": " + Saying);
                Thread.Sleep(1000);
            }
        }
    }
}
