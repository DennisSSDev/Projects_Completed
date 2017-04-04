using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Console_Stuff_Before_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an invasder object f
            InvaderZim dude = new InvaderZim(100);
            //Create the thread 
            Thread adam = new Thread(dude.Move);
            adam.Name = "Adam";
            //start the thread 
            adam.Start(8);
            //Show me the program is over
            adam.Join();
            adam.Interrupt();
            Console.WriteLine("Program is over");


            Thread tadeo = new Thread((object p) =>
            {


                Console.WriteLine("Our Parameter is: " + p);
                dude.Health = 100;
                
                dude.Move(p);
            }
            
            );
            tadeo.Start(3);

        }
    }
}
