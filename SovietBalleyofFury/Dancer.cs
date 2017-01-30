using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovietBalleyofFury
{
    class Dancer
    {
        public string Style { get; set; }

        public string Costume { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {//interview question waht is the best way to keep those strings together? Use concatinate
            //They want u to use string builder
            string buffer;
            buffer = Name + " " + Style + " " + Costume + " " + Age; //vALID BUT NOT EFFICIENT
            string.Concat(Name, Style, Costume, Age);
            StringBuilder sp = new StringBuilder();
            sp.AppendFormat("{0} {1} {2} {3}", Name, Style, Costume, Age); //Fastest way and want to see this 
            return sp.ToString();
        }
    }
}
