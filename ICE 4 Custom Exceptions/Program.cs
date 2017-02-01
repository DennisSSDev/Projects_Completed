using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_4_Custom_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Target newTarget = new Target();
            try
            {
                newTarget.ChangeHealth();
            }
            catch (HealthOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
