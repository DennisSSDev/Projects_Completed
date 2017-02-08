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
                writer.Write(plane1.Name +" " + plane1.Country +" " + plane1.TurnMode +" "+ plane1.AttackMode +" " + plane1.Cost +" "+ plane1.MaxDamage);//Write separately
            }
            using(var writeNewPlanes2 = File.OpenWrite("plane2.dat"))
            {
                var writer1 = new BinaryWriter(writeNewPlanes2);
                writer1.Write(plane2.Name + " " + plane2.Country + " " + plane2.TurnMode + " " + plane2.AttackMode + " " + plane2.Cost + " " + plane2.MaxDamage);
            }
            using (var writeNewPlanes3 = File.OpenWrite("plane3.dat"))
            {
                var writer2 = new BinaryWriter(writeNewPlanes3);
                writer2.Write(plane3.Name + " " + plane3.Country + " " + plane3.TurnMode + " " + plane3.AttackMode + " " + plane3.Cost + " " + plane3.MaxDamage);
            }
            using (var writeNewPlanes4 = File.OpenWrite("plane4.dat"))
            {
                var writer3 = new BinaryWriter(writeNewPlanes4);
                writer3.Write(plane4.Name + " " + plane4.Country + " " + plane4.TurnMode + " " + plane4.AttackMode + " " + plane4.Cost + " " + plane4.MaxDamage);
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
