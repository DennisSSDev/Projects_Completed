using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingOfTheDeadHW
{
    class Program
    {
        static void Main(string[] args)
        {
            ZombieData newData = new ZombieData(new List<string>(), new List<string>());

            newData.LoadPhrases("phrases.txt");
            newData.LoadZombies();
            Console.WriteLine(newData.RandomPhrase());
            Console.WriteLine(newData.RandomZombie());


        }
    }
}
