using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingOfTheDeadHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game(5, 0, 0, 0);//Do you have to initialize the entire thing? together with health and stuff????
            newGame.PlayGame();
        }
    }
}
