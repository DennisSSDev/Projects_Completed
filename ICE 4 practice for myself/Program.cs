using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_4_practice_for_myself
{
    class Program
    {
        static void Main(string[] args)
        {
            Target newCharacter = new Target("Jhon", 99);

            try
            {
                newCharacter.ChangeHealth(1000000000);
            }
            catch(HealthOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
