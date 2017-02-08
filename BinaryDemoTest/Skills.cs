using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDemoTest
{
    class Skills
    {
        public int Serving { get; set; }
        public double Madness { get; set; }

        public string Name { get; set; }
        public int Power { get; set; }
        public override string ToString()
        {
            return Name + " " + Madness;
        }
    }
}
