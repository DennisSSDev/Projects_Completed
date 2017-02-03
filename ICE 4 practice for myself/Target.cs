using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_4_practice_for_myself
{
    class Target
    {
        private string name;
        private int health;
        public string Name { get; set; }
        public int Health { get; set; }

        public Target(string pName, int pHealth)
        {
            this.name = pName;
            this.health = pHealth;
        }

        public void ChangeHealth(int billion)
        {
            health = billion;
            if(health<0 || health > 100)
            {
                throw new HealthOutOfRangeException(this, name);
            }
            else
            {
                Console.WriteLine("Health Within appropriate bounds");
            }

        }
    }
}
