using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace File_IODemo_ScottishCavemanOnTheOregonTrail_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader reader = new StreamReader("TextFile1.txt");
                string line;
                int cnt = 1;
                //while ((line = reader.ReadLine()) != null)
                //{
                // Console.WriteLine("Line number " + cnt + line);
                // cnt++;
                //}
                //reader.Close();
                line = reader.ReadToEnd();
                reader.Close();
                string[] lines =line.Split(',');
                foreach(var item in lines)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(line);
                StreamWriter writer= new StreamWriter("warmup2.txt");
                writer.WriteLine("Welcome to gdaps 2");//will write to the txt file, not output to console application 
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            SaveGame newSave = new SaveGame { Name = "CavemanHomoscotish", Lvl = 10 };
            StreamWriter gamewriter = new StreamWriter("savegame.json");
            string data = JsonConvert.SerializeObject(newSave);
            gamewriter.WriteLine(data);
            gamewriter.Close();

            StreamReader r2 = new StreamReader("savegame.json");
            string data2 = r2.ReadToEnd();
            r2.Close();
            Console.WriteLine(data2);
            SaveGame myGame = JsonConvert.DeserializeObject<SaveGame>(data2);
            Console.WriteLine(myGame.Name);


        }
    }
}
