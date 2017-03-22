using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace NetworkingICE
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string textLolz = "";

            TcpClient obj = new TcpClient("129.21.23.86", 14623);
            using (StreamWriter writeTxT = new StreamWriter(obj.GetStream()))
            {
                while (exit == false)
                {
                    
                    textLolz = Console.ReadLine();
                    writeTxT.WriteLine(textLolz);
                    writeTxT.Flush();
                    if (textLolz == "exit" || textLolz == "quit")
                    {
                        exit = true;
                    }
                }



            }


        }
    }
}
