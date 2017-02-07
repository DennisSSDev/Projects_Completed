using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingOfTheDeadHW
{
    class Game: ZombieData
    {
        private int playerLives;
        private int highScore;
        private int zombieTimer;
        private int letterIndex;
        //private List<string> initPhrases;
        //private List<string> initZombies;

        public Game(int pLives, int hScore, int zTimer, int lIndex)//set lives to five later
            :base(new List<string>() , new List<string>())
        {
            this.playerLives = pLives;
            this.highScore = hScore;
            this.zombieTimer = zTimer;
            this.letterIndex = lIndex;
            try
            {
                LoadPhrases("phrases.txt");
                LoadZombies();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Environment.Exit(0);
            } 
        }

        public void PlayGame()
        {
            string zombieHolder = "";
            string phrase = "";
            while (playerLives > 0)
            {
                //find a way to check if there is a zombie alive
                if(zombieHolder == "")
                {
                    zombieHolder = RandomZombie();
                    phrase = RandomPhrase().ToUpper();
                }
                char[] array = phrase.ToCharArray();
                zombieTimer = 0;
                letterIndex = 0;
                Console.WriteLine("Your Highscore: " + highScore + "\n\n\n" +
                    zombieHolder + "\n\n" + phrase );
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    string letter = key.KeyChar.ToString().ToUpper();//add a way of counting zombie minutes
                    if(letter[letterIndex] == phrase[letterIndex])
                    {
                        letterIndex++;
                        Console.WriteLine("!");
                    }
                    else
                    {
                        letterIndex = 0;
                        Console.WriteLine(":(");
                    }
                    if(letterIndex+1 == phrase.Length)
                    {
                        zombieHolder = "";
                        highScore += 10;
                    }
                    else if(letterIndex != phrase.Length && )//if a certain time passed attack the user 
                    {

                    }
                }

                
            }
        }
        
    }
}
