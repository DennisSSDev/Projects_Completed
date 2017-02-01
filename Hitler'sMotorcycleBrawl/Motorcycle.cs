using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitler_sMotorcycleBrawl
{
    class Motorcycle: Sprite
    {
        private int wheels;
        /// <summary>
        /// 
        /// </summary>
        /// <
        public int NumberOfWheels { get { return wheels; } set
            {
                if (value < 2)
                {
                    throw new MotorcycleException(this);
                }
                wheels = value;
            }
        }
        public float MaxSpeed { get; set; }

        public float Fuel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="MotorcycleException" >
        /// lolz
        /// </exception>
        /// <example>
        /// Motorcycle c = new Motorcycle(){NumberOfWheels = 0,etc =  0, etc = 0...};
        /// </example>
        public Motorcycle()
        {

        }


    }
}
