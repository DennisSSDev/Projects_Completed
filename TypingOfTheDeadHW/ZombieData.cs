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
                DirectoryInfo ForZombies = new DirectoryInfo("ForZombies");


                //DirectoryInfo newDirect = new DirectoryInfo(@"c:\");//ask the professor if valid
                
            
                FileInfo[] allZombieFiles = ForZombies.GetFiles("zombie1.txt");//Problem Here
                for(int i = 0; i<allZombieFiles.Count<FileInfo>(); i++)
                {
                    zombies.Add(allZombieFiles[i].OpenRead());
                }
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
            return zombies[0];
        }
    }
}
