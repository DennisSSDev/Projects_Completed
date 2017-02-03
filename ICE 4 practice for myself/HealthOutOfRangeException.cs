using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_4_practice_for_myself
{
    class HealthOutOfRangeException:Exception
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        Target inputOfError;

        public HealthOutOfRangeException(Target pInput,string pName)
            :base("Yo, u done screwed up, health out of range for the target")
        {
            inputOfError = pInput;
            name = pName;
        }
    }
}
