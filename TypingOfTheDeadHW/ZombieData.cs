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
        private List<string> zombies;
        private List<string> phrases;
        public ZombieData(List<string> pZombies, List<string> pPhrases)
        {
            zombies = pZombies;
            phrases = pPhrases;
        }

        public void LoadPhrases(string filename)
        {
            try
            {
                StreamReader txtReader = new StreamReader(filename);
                while(txtReader.EndOfStream == false)
                {
                    phrases.Add(txtReader.ReadLine());//ask the professor if valid
                }
                
                txtReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoadZombies()
        {
            string zName = "zombie1";

   
            try
            {



                //DirectoryInfo newDirect = new DirectoryInfo(@"c:\");//ask the professor if valid
                string[] zombieFiles = Directory.GetFiles(@"ForZombies", "zombie*");
                foreach (var item in zombieFiles)
                {
                    StreamReader zombieReader = new StreamReader(item);
                    zombies.Add(zombieReader.ReadToEnd());
                }
            
                 //Problem Here


                //foreach(var item in allZombieFiles)
                //{
                    
                    //zombies.Add(item.OpenText().ToString());//ask if this method closes itself
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string RandomPhrase()
        {
            Random newCountOfRandom1 = new Random();
            int countForStringsInPhrases = phrases.Count;
            int foundNum = newCountOfRandom1.Next(0, countForStringsInPhrases);
            return phrases[foundNum];
        }
        public string RandomZombie()
        {
            Random newCountOfRandom2 = new Random();
            int countForStringsInZombies = zombies.Count;
            int foundNum = newCountOfRandom2.Next(0, countForStringsInZombies);
            return zombies[foundNum];
        }
    }
}
