using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3_LinkedList
{
    class Node
    {

        public Node Link { get; set; }
        public string Data { get; set; }
        public Node(string data)
        {
            Data = data;
        }
        public override string ToString()
        {
            return Data;
        }
    }
}
