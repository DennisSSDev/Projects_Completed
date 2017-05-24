using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    class Barcelona
    {
        //Similar ideas that the real players have but they should pass more 
        public string  Name { get; set; }
        public int Speed { get; set; }
        public int Skill { get; set; }

        public Barcelona(string name, int speed, int skill)
        {
            Name = name;
            Speed = speed;
            Skill = skill;
        }

        //Make a method for movement that depends on the speed
            //there should be a checker that takes the x pos and y pos determining if it's ok to shoot
        //make a method that when on collision moves in a different direction/outskills the obstruction/pass the ball to another player
            //if the player chooses to either outskill or pass, there should be a chance of lousing the ball to the opposition

    }
}
