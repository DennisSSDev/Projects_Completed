using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreSessionReview_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Skateboard complex = new Skateboard();
            complex.RetrievePassInfo(complex.Name);
            Vehicle truck = new Vehicle(3, 0, "Truck", "A-1Qs");
            Vehicle v = new Skateboard();
            Skateboard t = (Skateboard)v;
            t.OnlySkate();
        }
    }
}
