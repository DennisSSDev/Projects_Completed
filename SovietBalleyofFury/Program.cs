using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovietBalleyofFury
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dancer> soviet = new List<Dancer>();
            List<Dancer> american = new List<Dancer>();
            american.Add(new Dancer { Name = "Kat", Style = "Swing", Costume = "Cowgirl", Age = 21 });
            soviet.Add(new Dancer { Name = "Tailor", Style = "Kazhak", Costume = "Traditional", Age = 45 });
            int ageSum = 0;
            int ageCount = 0;
            try
            {
                foreach (var item in american)
                {
                    ageSum = item.Age;
                }
                Console.WriteLine("Av american age is: " + ageSum / ageCount);
            }
            catch (Exception ex)
            {

                Console.WriteLine("There is an error");
            }
         

        }
    }
}
