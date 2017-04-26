using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkGame_ICE_for_graphs
{
    class AdjacencyList
    {
        Dictionary<String, List<String>> adjDict = new Dictionary<string, List<string>>();
        
        public AdjacencyList()
        {
            Vertex alRoom = new Vertex("Alessandro's shitty room");
            Vertex sol = new Vertex("Sol");
            Vertex outsideWorld = new Vertex("Outside World");
            Vertex golisano = new Vertex("Golisano");
            Vertex steveOffice = new Vertex("Steve's Office");
            List<string> listForalRoom = new List<string>();
            listForalRoom.Add(sol.RoomName);
            listForalRoom.Add(outsideWorld.RoomName);
            List<string> listForSol = new List<string>();
            listForSol.Add(alRoom.RoomName);
            listForSol.Add(outsideWorld.RoomName);
            List<string> listForWorld = new List<string>();
            listForWorld.Add(alRoom.RoomName);
            listForWorld.Add(sol.RoomName);
            listForWorld.Add(golisano.RoomName);
            List<string> listForGolisano = new List<string>();
            listForGolisano.Add(outsideWorld.RoomName);
            listForGolisano.Add(steveOffice.RoomName);
            List<string> listForSteve = new List<string>();
            listForSteve.Add(golisano.RoomName);

            adjDict.Add(alRoom.RoomName, listForalRoom);
            adjDict.Add(sol.RoomName, listForSol);
            adjDict.Add(outsideWorld.RoomName, listForWorld);
            adjDict.Add(steveOffice.RoomName, listForSteve);
            adjDict.Add(golisano.RoomName, listForGolisano);
        }

        public List<String>GetAdjacentList(string room)
        {   
            return adjDict[room];
        }
        public Boolean IsConnected(String room1, String room2)
        {
            try
            {



                if (adjDict[room1].Contains(room2))
                {
                    return true;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Nonesense");
                return false;
            } 
                return false;
            
        }
    }
}
