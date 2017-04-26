using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkGame_ICE_for_graphs
{
    class Vertex
    {
        public String RoomName { get; set; }
        public Vertex(string name)
        {
            RoomName = name;
        }
    }
}
