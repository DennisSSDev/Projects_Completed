using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                if (zombieHolder == "")
                {
                    zombieHolder = RandomZombie();
                    phrase = RandomPhrase();
                    zombieTimer = 0;
                    letterIndex = 0;
                    Console.WriteLine("\nYour Highscore: " + highScore + "\n\n\n" +
                    zombieHolder + "\n\n" + phrase);
                }
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    string letter = key.KeyChar.ToString().ToUpper();//add a way of counting zombie minutes
                    string compareLetter = phrase[letterIndex].ToString().ToUpper();
                    if (letter == compareLetter)
                    {
                        letterIndex++;
                        Console.Write("!");
                       //In Either Way Print to the console with a ! and :(, but how???? if the Console Key would read everything and would start comparing it
                    }//How to fix the problem with completely deleting the word and going negative
                    else
                    {
                        letterIndex = 0;//You mean that if they get just a single word wrong they have to retype??
                        Console.Write(":(");
                    }
                    if (letterIndex == phrase.Length)
                    {
                        zombieHolder = "";
                        highScore += 10;
                        zombieTimer = 0;
                        break;
                    }
                    System.Threading.Thread.Sleep(100);//How to make thios timer work?????
                    {
                        zombieTimer+=1;
                    }
                    if (zombieTimer >= 10)
                    {


                        //how to make the Console.KeyAvailable false? and how to count time with zombie timer
                            playerLives--;
                            Console.WriteLine("\nYou got hit you now have " + playerLives + " lives\n");
                            zombieTimer = 0;
                            System.Threading.Thread.Sleep(50);
                            {
                                zombieTimer += 1;
                            }
                    }
                    
                }

                
            }
            Console.WriteLine("You lost, thank you for playing your highscore is: " + highScore);
        }
        
    }
}
