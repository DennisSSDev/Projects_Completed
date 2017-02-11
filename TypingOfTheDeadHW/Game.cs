using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TypingOfTheDeadHW//IMPORTANT!!!!! The highscore doesn't update immediately after you close the program for some reason, but it will on the second try, idk why
    //might want to click update the files or smth, this is a bit out of my control
{
    class Game: ZombieData
    {
        private int playerLives;//private variable for storing information(they are quite self explanatory)
        private int highScore;
        private int score;
        private int zombieTimer;
        private int letterIndex;
        private ZombieData zombieAttribute;//Zombie object for retrieval of lists
        public Game()
            :base(new List<string>(), new List<string>())//need to use base class since inheriting 
        {
            this.playerLives = 5;//initialize all the variables that make sense to initialize
            this.zombieTimer = 0;
            this.letterIndex = 0;
            this.score = 0;//keeps track of the score duirng play (NOT HIGHSCORE)

            try//incase the zombie Files won't be found, complain 
            {
                zombieAttribute = new ZombieData(new List<string>(), new List<string>());
                LoadPhrases("phrases.txt");
                LoadZombies();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Environment.Exit(0);//close the program completely, y would u continue playing if there are no zombies to kill?
            } 
        }
        public int readScore()//this method returns the int from our Highscore.dat file, if it doesn't exist, return 0
        {
            try//in case the file won't be found, return 0
            {
                using (var reader = File.OpenRead("Highscore.dat"))//reading the file
                {
                    var readFiles = new BinaryReader(reader);
                    return readFiles.ReadInt32();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void WriteScore()//if the current score that the user accumilated is greater than the highest score, write a new highscore to the Highestscore.dat
        {
           if(score >= highScore)
            {
                using (var writer = File.OpenWrite("HighScore.dat"))
                {
                    var writerOfFiles = new BinaryWriter(writer);
                    highScore = score;
                    writerOfFiles.Write(highScore);
                }
            }
        }
        public void PlayGame()//method for playing the game 
        {
            string zombieHolder = "";//determines if the zombie is alive or not
            string phrase = "";//will hold the random phrase
            int i = 0;//this variable will reduce the amount of time the player will have until the next zombie attack
            highScore = readScore();//store the highest score int to show the user later
            Console.WriteLine("Previous High Score is: " + highScore);
            while (playerLives > 0)//until the player runs out of lives, do this 
            {
                if (zombieHolder == "")//if the zombie is "dead" do this
                {
                    zombieHolder = RandomZombie();//assign a zombie
                    phrase = RandomPhrase();//asign phrase
                    zombieTimer = 0;//reset timer
                    letterIndex = 0;//reset letter counter
                    Console.WriteLine("\nYour score: " + score + "\n" +
                    zombieHolder + "\n" + phrase);
                }
                while (Console.KeyAvailable)//read letter input
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    string letter = key.KeyChar.ToString().ToUpper();
                    string compareLetter = phrase[letterIndex].ToString().ToUpper();
                    if (letter == compareLetter)//in case the letter out of the phrase matches the entered letter, increase the index and write ! in front
                    {
                        letterIndex++;
                        Console.Write("!");
                    }
                    else
                    {//if the user fails to enter the correct letter at least once, he will have to stat over typing the letters
                        letterIndex = 0;
                        Console.Write(":(");
                    }
                    if (letterIndex == phrase.Length)//if the user's input mathces the entire length of the random phrase, kill the zombie and award points, increase difficulty
                    {
                        zombieHolder = "";
                        score += 10;
                        zombieTimer = 0;
                        i += 10;//difficulty increase
                    }
                }
                System.Threading.Thread.Sleep(50);//every 50 miliseconds increase the zombie counter by 1, I think this is fair enough
                zombieTimer += 1;
                if (zombieTimer == 200-i && letterIndex != phrase.Length)//in case the player runs out of time, the zombie hits him and he has to restart typing the same word again
                {
                    letterIndex = 0;
                    playerLives--;
                    Console.WriteLine("\nYou got hit you now have " + playerLives + " lives\n");
                    
                    zombieTimer = 0;//reset the timer until the next hit
                }
            }
            WriteScore();//this will adjust the highscore if the player performed amazingly and beat the previous one
            Console.WriteLine("You lost, thank you for playing your score is: " + score);
            Console.WriteLine("Highest score: " + highScore);
        }
        
    }
}
