using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryDemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Skills newPlayer1 = new Skills() { Name = "Jackie Chan", Power = 9000, Serving = 100, Madness = 0 };
            Skills newPlayer2 = new Skills() { Name = "Willy Wonka", Power = 100, Serving = 10, Madness = 200000 };

            using (var outStream = File.OpenWrite("players.dat"))
            {
                //using will close this without having to use .Close(), even with Stream Reader and txt files
                var writer = new BinaryWriter(outStream);
                writer.Write(newPlayer2.Name);
                writer.Write(newPlayer2.Serving);
                writer.Write(newPlayer2.Power);
                writer.Write(newPlayer2.Madness);
                writer.Write(newPlayer1.Name);
                writer.Write(newPlayer1.Serving);
                writer.Write(newPlayer1.Power);
                writer.Write(newPlayer1.Madness);
            }
            using (var outBson = File.OpenWrite("player.bson"))
            {
                var writer = new Bsonwriter(outBson);
                jsonSerializer rial = new jsonSerializer();
                rial.Serialize(writer, player1);
                rial.Serialize(writer, player2);
            }
            Skills player3 = new Skills() { };
            Skills player4 = new Skills() { };
            using (var intStream = File.OpenRead("players.dat"))
            {
                var reader = new BinaryReader(intStream);
                player3.Name = reader.ReadString();//reads from top to bottom and have to match the order
                player3.Serving = reader.ReadInt32();
                player3.Power = reader.ReadInt32();
                player3.Madness = (float)reader.ReadDouble();
                player4.Name = reader.ReadString();
                player4.Serving = reader.ReadInt32();
               
                Console.WriteLine(player3);
                Console.WriteLine(player4);
            }
        
        }
    }
}
