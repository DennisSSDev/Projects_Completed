using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TypingOfTheDeadHW
{
    class ZombieData
    {
        private List<string> zombies;//private variiables used to store data of incoming zombies and phrases in a list
        private List<string> phrases;
        public ZombieData(List<string> pZombies, List<string> pPhrases)//consructor for the ZombieData class
        {
            zombies = pZombies;
            phrases = pPhrases;
        }

        public void LoadPhrases(string filename)//this method loads a file phrases.txt and stores them in a list for further use
        {
            try//in case the file gets deleted the console will complaine 
            {
                StreamReader txtReader = new StreamReader(filename);//reading the file
                while(txtReader.EndOfStream == false)//as long as we can read the file do this 
                {
                    phrases.Add(txtReader.ReadLine());
                }
                
                txtReader.Close();//don't forget to close the txt reader
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//in case the user deletes the file, program will complain 
            }
        }
        public void LoadZombies()
        {
            try//in case the user deletes all of the zombie files or even the directory to the zombie files, program will complain
            {
                string[] zombieFiles = Directory.GetFiles(@"ForZombies", "zombie*");//search in the ForZombies directory for any zombie files and store the names in the string
                foreach (var item in zombieFiles)//if found names, store the contained zombies to the zombie list 
                {
                    StreamReader zombieReader = new StreamReader(item);
                    zombies.Add(zombieReader.ReadToEnd());
                    zombieReader.Close();//don't forget to close the list
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//complain if no files were found
            }
        }
        public string RandomPhrase()//a randomizer method that chooses one random zombie and stores it in the zombie list, if the list doesn't contain anything return null
        {
            Random newCountOfRandom1 = new Random();
            try
            {
                int countForStringsInPhrases = phrases.Count;
                int foundNum = newCountOfRandom1.Next(0, countForStringsInPhrases);
                return phrases[foundNum];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string RandomZombie()//A method to randomly choose a zombie and store it in the list, if the list doesn't contain anything return null
        {
            Random newCountOfRandom2 = new Random();
            try
            {
                int countForStringsInZombies = zombies.Count;
                int foundNum = newCountOfRandom2.Next(0, countForStringsInZombies);
                return zombies[foundNum];
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
