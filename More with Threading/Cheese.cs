﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace More_with_Threading
{
    class Cheese
    {
        public int Firmness { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }
        
        public void AgeCheese()
        {
            try
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": Age cheese Begin");
                Thread.Sleep((int)Age * 1000);
                Console.WriteLine("Age cheese End");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void CheeseMessingAround(object Firmness)
        {
            if(Firmness == null)
            {
                return;
            }
            else
            {
                if((int)Firmness < 10)
                {
                    Console.WriteLine("That's some weak cheese you got there");
                }
                else
                {
                    Console.WriteLine("Nice Firmness");
                }
            }
        }
    }
}
