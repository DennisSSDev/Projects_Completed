using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Tree_practise
{
    class LinkedList
    {
        NodeList obj;
        public LinkedList()
        {

        }
        public void AddNode()
        {
            while (obj != null)
            {
                obj = obj.Node;
            }
            if (obj == null)
            {
                Random gen = new Random();
                obj = new NodeList() { Number = gen.Next(0, 101) };
            }

        }
        public int findNum(int count)
        {
            NodeList nodeHold = obj;
            int counter = 0;
            while(counter != count)
            {
                nodeHold = nodeHold.Node;
                counter++;
            }
            return nodeHold.Number;
        }
    }
}
