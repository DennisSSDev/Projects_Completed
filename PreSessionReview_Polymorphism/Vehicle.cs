using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace PreSessionReview_Polymorphism
{
    class Vehicle
    {
        private Dictionary<string, string> vehicleDatabase = new Dictionary<string, string>();
        private Dictionary<string, int> vehINSData = new Dictionary<string, int>();

        private int wheelsAMT;
        private int passngrCNT;
        private string name;
        private string model;

        public int WheelsAMT { get { return wheelsAMT; } }
        public int PassngrCNT { get { return passngrCNT; } }
        public string Name { get { return name; } }
        public string Model { get { return model; } }

        public Vehicle(int pWheels, int pPassngr, string pName, string pModel)//adjust the retrieval 
        {
            wheelsAMT = pWheels;
            passngrCNT = pPassngr;
            name = pName;
            model = pModel;
        }
        public virtual int RetrievePassInfo(string key)
        {
            int temp = 0;
            if (vehicleDatabase.ContainsKey(key))
                Console.WriteLine(vehicleDatabase[key] + " is looked at");
            else
                return -1;
            Thread.Sleep(5000);
            foreach (var item in vehINSData.Keys)
            {
                if(item == key)
                {
                    temp++;
                    break;
                }
            }
            if (temp > 0)
                return vehINSData[key];
            else
            {
                return -1;
            }
        }

    }
}
