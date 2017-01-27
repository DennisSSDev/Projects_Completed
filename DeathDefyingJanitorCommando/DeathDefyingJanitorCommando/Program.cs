using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathDefyingJanitorCommando
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Gogogogo
            ///
            Dictionary<string, Janitor> squad = new Dictionary<string, Janitor>();

            Janitor jan1 = new Janitor();
            jan1.Name = "Jan";
            jan1.BroomSize = 24.5f;
            squad.Add("leader", jan1);
            squad.Add("plunger", new Janitor
            {
             Name="George", BroomSize = 3
            });

            squad.Add("mop", new Janitor
            {
                Name = "George2",
                BroomSize = 3
            });
            squad.Add("bucket", new Janitor
            {
                Name = "George3",
                BroomSize = 3
            });

            Console.WriteLine(jan1.ToString());
            Console.WriteLine(squad["leader"]);
            foreach (var item in squad)
            {
                Console.WriteLine(item);
            }



           

        }
    }
}
