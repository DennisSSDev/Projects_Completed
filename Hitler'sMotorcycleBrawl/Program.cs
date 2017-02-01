using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hitler_sMotorcycleBrawl
{
    /// <summary>
    /// Our motorcycle class 
    /// </summary>
    /// <exception cref="MotorcycleException" />
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Motorcycle m = new Motorcycle() { Fuel = 0, X = 100, Y = 100, MaxSpeed = 250, NumberOfWheels = 1 };
                //File.OpenRead()
            }
            catch (MotorcycleException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }
    }
}
