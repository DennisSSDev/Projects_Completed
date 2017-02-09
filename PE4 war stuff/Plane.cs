using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4_war_stuff
{
    class Plane
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public char TurnMode { get; set; }
        public char AttackMode { get; set; }
        public double Cost { get; set; }
        public int MaxDamage { get; set; }

        public override string ToString()
        {
            return "\nName: " + Name + "\nCountry: " + Country + "\nTurn Mode: " + TurnMode + "\nAttack Mode: " + AttackMode + "\nCost: " + Cost + "\nMax Damage: " + MaxDamage + "\n";
        }
    }
}
