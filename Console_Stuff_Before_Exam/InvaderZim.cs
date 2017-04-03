using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Stuff_Before_Exam
{
    class InvaderZim
    {
        //health property
        public int Health { get; set; }
        public InvaderZim(int health)
        {
            Health = health;
        }
        //Make a constructor that takes one parameter(strenght of invader zim)
        //Make a move method that moves the character

        public void Move(object min)
        {
            Random newRandom = new Random();
            while (Health > 0)
            {
                if(min == null)
                {
                    return;
                }
                int damage = newRandom.Next((int)min,10);
                Console.WriteLine("you took: " + damage + " damage" );
                TakeDMG(damage);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        //And a take dmg method that suptracts from the health
        public void TakeDMG(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Console.WriteLine("You dead");
            }
        }
    }
}
