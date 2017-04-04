using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace More_with_Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            object locker = new object();
            Cheese obj = new Cheese() { Name = "Swiss", Firmness = 10, Age = 4.5f };

            Thread t = new Thread(obj.AgeCheese);
            t.Start();
            Thread t2 = new Thread(() => {
                lock (locker)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + i);
                    }
                }


            });
            Thread t3 = new Thread(() =>
            {
                lock (locker)
                {


                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine(i + "num" );
                    }
                }

            });
            t2.Start();
            t3.Start();
            Cheese newCheese = new Cheese() { Name = "SomeCheese", Age = 220000, Firmness = 11 };
            Thread t4 = new Thread(newCheese.CheeseMessingAround);
            t4.Start(newCheese.Firmness);
            t4.Join();
        }
    }
}
