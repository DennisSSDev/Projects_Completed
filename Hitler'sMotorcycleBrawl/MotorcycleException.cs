using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitler_sMotorcycleBrawl
{
    /// <summary>
    /// our motorcycle exception 
    /// </summary>
    class MotorcycleException: Exception
    {
        Motorcycle data;

        public MotorcycleException(Motorcycle cycle): base("You messed up defining your bike")
        {
            data = cycle;
        }
    }
}
