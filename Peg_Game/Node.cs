using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peg_Game
{
    class Node
    {
        public Node Next { get; set; }
        public Pins Data { get; set; }
        public Node(Pins data_)
        {
            Data = data_;
        }
        public int GetPinNumber()
        {
            return Data.PinNum;
        }
    }
}
