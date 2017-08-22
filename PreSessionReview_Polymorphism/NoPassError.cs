using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreSessionReview_Polymorphism
{
    class NoPassError:Exception
    {
        public NoPassError():base("This vehicle has no passengers")
        {

        }
    }
}
