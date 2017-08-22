using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreSessionReview_Polymorphism
{
    class Skateboard: Vehicle
    {

        public Skateboard()
            : base(4,0,"Skateboard", "Complex")
        {}
        public override int RetrievePassInfo(string key)
        {
            try
            {
                if (this.PassngrCNT <= 0)
                {
                    throw new NoPassError();
                }
                else
                {
                    Console.WriteLine("all is good");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public void OnlySkate()
        {
            Console.WriteLine("only skates can use this");
        }
    }
}
