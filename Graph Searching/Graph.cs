using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Searching
{
    class Graph
    {
        Vertex[] vertexList = new Vertex[5];
        int[,] connections = new int[5,5];

        Dictionary<String, List<String>> adjDict = new Dictionary<string, List<string>>();
        public Graph()
        {
            Vertex alRoom = new Vertex("Alessandro's shitty room");
            Vertex sol = new Vertex("Sol");
            Vertex outsideWorld = new Vertex("Outside World");
            Vertex golisano = new Vertex("Golisano");
            Vertex steveOffice = new Vertex("Steve's Office");

            vertexList[0] = alRoom;
            vertexList[1] = sol;
            vertexList[2] = outsideWorld;
            vertexList[3] = golisano;
            vertexList[4] = steveOffice;

            connections[0,0] = 0;//Ales room
            connections[0, 1] = 1;
            connections[0, 2] = 1;
            connections[0, 3] = 0;
            connections[0, 4] = 0;

            //sol

            connections[1, 0] = 1;
            connections[1, 1] = 0;
            connections[1, 2] = 1;
            connections[1, 3] = 0;
            connections[1, 4] = 0;

            //outside wolrd

            connections[2, 0] = 1;
            connections[2, 1] = 1;
            connections[2, 2] = 0;
            connections[2, 3] = 1;
            connections[2, 4] = 0;

            //golisano

            connections[3, 0] = 0;
            connections[3, 1] = 0;
            connections[3, 2] = 1;
            connections[3, 3] = 0;
            connections[3, 4] = 1;

            //steves office

            connections[4, 0] = 0;
            connections[4, 1] = 0;
            connections[4, 2] = 0;
            connections[4, 3] = 1;
            connections[4, 4] = 0;
        }

        public List<String> GetAdjacentList(string room)
        {
            int count = 0;
            List<String> someString = new List<string>();
            foreach (var item in vertexList)
            {        
                if (item.RoomName == room)
                {
                    break;
                }
                count++;
            }

            for (int i = 0; i < 5; i++)
            {
                if (connections[count,i] == 1)
                {
                    someString.Add(vertexList[i].RoomName);
                }
            }
            return someString;
        }
        public bool IsConnected(String room1, String room2)
        {
            int count1 = 0;
            int count2 = 0;
            foreach (var item in vertexList)
            {
                if (room1 == item.RoomName)
                    break;
                count1++;
            }
            foreach (var item in vertexList)
            {
                if (room2 == item.RoomName)
                    break;
                count2++;
            }
            if(connections[count1, count2] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
