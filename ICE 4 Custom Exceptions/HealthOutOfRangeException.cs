using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE_4_Custom_Exceptions
{
    class HealthOutOfRangeException: Exception
    {
        
        Target player;

        public HealthOutOfRangeException(Target pPlayer): base ("Error, health wasn't set within the bounds") 
        {
            this.player = pPlayer;

        }
    }
}
