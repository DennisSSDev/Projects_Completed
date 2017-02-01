using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_4_Custom_Exceptions
{
    class Target
    {
        private int health;
        public int Health { get { return health; } set
            {
                if(health < 0 || health > 100)
                {
                    throw new HealthOutOfRangeException(this);
                }
                health = value;
            }
        }
        public string Name { get; set; }

        public Target(string Pname = "Storm", int PHealth = 50)
        {
            this.Name = Pname;
            this.health = PHealth;

        }

        public void ChangeHealth()
        {
            int takeNum = 10000;
            health = takeNum;
            if (health < 0 || health > 100)
            {
                throw new HealthOutOfRangeException(this);
            }
           
        }
    }
}
