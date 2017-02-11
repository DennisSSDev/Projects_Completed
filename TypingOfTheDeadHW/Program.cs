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
            Game newGame = new Game();//simply creating the game oblect to be able to launch the play game method
            newGame.PlayGame();
        }
    }
}
