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
            Plane plane1 = new Plane() { Name = "Fokker DR 1", Country = "Germany", TurnMode = 'A', AttackMode = 'A', Cost = 1000.00, MaxDamage = 13 };
            Plane plane2 = new Plane() { Name = "SPAD XII", Country = "France", TurnMode = 'A', AttackMode = 'A', Cost = 1250.50, MaxDamage = 16 };
            Plane plane3 = new Plane() { Name = "Sopwith Camel", Country = "England", TurnMode = 'C', AttackMode = 'A', Cost = 890.70, MaxDamage = 15 };
            Plane plane4 = new Plane() { Name = "Albatros D", Country = "Germany", TurnMode = 'B', AttackMode = 'A', Cost = 1570.70, MaxDamage = 15 };

            using(var writeNewPlanes = File.OpenWrite("plane1.dat"))
            {
                var writer = new BinaryWriter(writeNewPlanes);
                writer.Write(plane1.Name);
                writer.Write(plane1.Country);
                writer.Write(plane1.TurnMode);
                writer.Write(plane1.AttackMode);
                writer.Write(plane1.Cost);
                writer.Write(plane1.MaxDamage);
                
            }
            using(var writeNewPlanes2 = File.OpenWrite("plane2.dat"))
            {
                var writer1 = new BinaryWriter(writeNewPlanes2);
                writer1.Write(plane2.Name);
                writer1.Write(plane2.Country);
                writer1.Write(plane2.TurnMode);
                writer1.Write(plane2.AttackMode);
                writer1.Write(plane2.Cost);
                writer1.Write(plane2.MaxDamage);
            }
            using (var writeNewPlanes3 = File.OpenWrite("plane3.dat"))
            {
                var writer2 = new BinaryWriter(writeNewPlanes3);
                writer2.Write(plane3.Name);
                writer2.Write(plane3.Country);
                writer2.Write(plane3.TurnMode);
                writer2.Write(plane3.AttackMode);
                writer2.Write(plane3.Cost);
                writer2.Write(plane3.MaxDamage);
            }
            using (var writeNewPlanes4 = File.OpenWrite("plane4.dat"))
            {
                var writer3 = new BinaryWriter(writeNewPlanes4);
                writer3.Write(plane4.Name);
                writer3.Write(plane4.Country);
                writer3.Write(plane4.TurnMode);
                writer3.Write(plane4.AttackMode);
                writer3.Write(plane4.Cost);
                writer3.Write(plane4.MaxDamage);
            }

            string[] planeFiles = Directory.GetFiles(Directory.GetCurrentDirectory(),"plane*");
            foreach (var item in planeFiles)
            {
                var intStream = File.OpenRead(item);
                var reader = new BinaryReader(intStream);
                Plane newPlane = new Plane();
                newPlane.Name = reader.ReadString();//reads from top to bottom and have to match the order
                newPlane.Country = reader.ReadString();
                newPlane.TurnMode = reader.ReadChar();
                newPlane.AttackMode = reader.ReadChar();
                newPlane.Cost = reader.ReadDouble();
                newPlane.MaxDamage = reader.ReadInt32();
                Console.WriteLine(newPlane);
            }


        }
    }
}
