using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Searching
{
    class Vertex
    {
        public string RoomName { get; set; }
        public bool Visited { get; set; }
        public Vertex(string name, bool visited = false)
        {
            this.RoomName = name;
            this.Visited = visited;
        }

    }
}
