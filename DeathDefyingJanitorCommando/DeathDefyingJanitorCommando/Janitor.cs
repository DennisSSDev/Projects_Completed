using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathDefyingJanitorCommando
{
    class Janitor
    {
        public string Name { get; set; }

        private float _broomSize;

        public float BroomSize
        {
            get { return _broomSize; }
            set { _broomSize = value; }
        }

        public override string ToString()
        {
            return Name + " " + BroomSize;
        }

    }
}
