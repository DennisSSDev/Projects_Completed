using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PE4_war_stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter newWriter = new StreamWriter("NameOfFighters.txt");
            string txt = "Name: Fokker DR 1 | Country: Germany | Turn Mode: D | Attack Mode: A | Max Damage 13,SPAD XII | France | A | A | 16,Sopwith Camel | England | C | A | 15,Albatros D | Germany | B | A | 15";
            newWriter.Write(txt);
            newWriter.Close();
            StreamReader newReader = new StreamReader("NameOfFighters.txt");
            string input = newReader.ReadToEnd();
            newReader.Close();
            string[] lines = input.Split(',');
            foreach(var item in lines)
            {
                Console.WriteLine(item);
            }


        }
    }
}
