using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_ICE
{
    class Node
    {
        public string Data { get; set; }
        public Node Link { get; set; }

        public Node(string data)
        {
            this.Data = data;
            Link = null;

            //int? d = null; Allows you to make a null value for an int 
            //float? f = 6.0f;

        }
        public override string ToString()
        {
            return Data;
        }
    }
}
