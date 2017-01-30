using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_for_week_2__exceptions_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayList = new string[5];
            for(int i = 0; i < 5; i++)
            {
                arrayList[i] = "Lol this is garbage";
            }
            string quit = "";
            int index = 0;

            while(quit != "quit")
            {
                Console.WriteLine("Enter index of the array you would like to change" );
                quit = Console.ReadLine();
                try
                {
                    if (int.TryParse(quit, out index) == true)
                    {
                        Console.WriteLine("Enter what you want to change");
                        arrayList[index] = Console.ReadLine();
                    }
                    else if(int.TryParse(quit, out index) == false)
                    {
                        if (quit == "quit")
                        {
                            break;
                        }
                        else if(quit == "print")
                        {
                            for(int i = 0; i<5; i++)
                            {
                                Console.WriteLine(arrayList[i]);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in code, consider revising");
                    Console.WriteLine("Enter a new index");
                }
            }
        }
    }
}
