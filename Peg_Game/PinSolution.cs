using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peg_Game
{
    class PinSolution
    {
        //Use a stack whenever you get options you start with the smallest number and store it in a temp value if the next move gets you stuck recall and try any other number but the number you just tried
        //record the moves in a string but if you call back
        public List<Pins> allPins = new List<Pins>();
        public Dictionary<int, List<int>> memberConnections = new Dictionary<int, List<int>>();
        public List<int> connections0 = new List<int>();
        public List<int> connections1 = new List<int>();
        public List<int> connections2 = new List<int>();
        public List<int> connections3 = new List<int>();
        public List<int> connections4 = new List<int>();
        public List<int> connections5 = new List<int>();
        public List<int> connections6 = new List<int>();
        public List<int> connections7 = new List<int>();
        public List<int> connections8 = new List<int>();
        public List<int> connections9 = new List<int>();
        public List<int> connections10 = new List<int>();
        public List<int> connections11 = new List<int>();
        public List<int> connections12 = new List<int>();
        public List<int> connections13 = new List<int>();
        public List<int> connections14 = new List<int>();

        public Stack<string> moves = new Stack<string>();

        private int startEmptyPin = 0;
        private int winCount = 0;
        private int RemovedPins = 0;
        string moves1 = null;
        public PinSolution()
        {
            //add all the pins to a single data struct
            allPins.Add(new Pins() { PinNum = 0, Visited = true, Current = true });//if a pin exists at the spot it has a letter N, if not it has letter E
            allPins.Add(new Pins() { PinNum = 1, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 2, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 3, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 4, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 5, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 6, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 7, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 8, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 9, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 10, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 11, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 12, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 13, Visited = false, Current = false });
            allPins.Add(new Pins() { PinNum = 14, Visited = false, Current = false });

            connections0.Add(3);
            connections0.Add(5);

            connections1.Add(6);
            connections1.Add(8);

            connections2.Add(7);
            connections2.Add(9);

            connections3.Add(0);
            connections3.Add(5);
            connections3.Add(10);
            connections3.Add(12);

            connections4.Add(11);
            connections4.Add(13);

            connections5.Add(0);
            connections5.Add(3);
            connections5.Add(12);
            connections5.Add(14);

            connections6.Add(1);
            connections6.Add(8);

            connections7.Add(2);
            connections7.Add(9);

            connections8.Add(1);
            connections8.Add(6);

            connections9.Add(2);
            connections9.Add(7);


            connections10.Add(3);
            connections10.Add(12);

            connections11.Add(4);
            connections11.Add(13);

            connections12.Add(3);
            connections12.Add(5);
            connections12.Add(10);
            connections12.Add(14);

            connections13.Add(4);
            connections13.Add(11);

            connections14.Add(5);
            connections14.Add(12);

            memberConnections.Add(0, connections0);
            memberConnections.Add(1, connections1);
            memberConnections.Add(2, connections2);
            memberConnections.Add(3, connections3);
            memberConnections.Add(4, connections4);
            memberConnections.Add(5, connections0);
            memberConnections.Add(6, connections1);
            memberConnections.Add(7, connections2);
            memberConnections.Add(8, connections3);
            memberConnections.Add(9, connections4);
            memberConnections.Add(10, connections2);
            memberConnections.Add(11, connections3);
            memberConnections.Add(12, connections4);
            memberConnections.Add(13, connections3);
            memberConnections.Add(14, connections4);
        }
        public string AddText(string given, int a, int b)
        {
            given += "From " + a + " to " + b + "\n";
            return given;
        }
        public string RemoveText(string given)
        {
        
            return given.Remove(given.Length-12, 12);
        }

        public void Reset(int nextEmptyPin)
        {
            winCount++;
            RemovedPins = 0;
            foreach (var item in allPins)
            {
                item.Visited = false;
            }
            allPins[nextEmptyPin].Visited = true;
            allPins[nextEmptyPin].Current = true;

        }

        public void PlayGame()
        {
            if(winCount == 15)
            {
                return;
            }

            if(RemovedPins == 14)
            {
                //You also need to send all of the information regarding the movement to the text box and then erase all the moves from the temp holder            
                Reset(startEmptyPin++);
            }
            PlayGame();
                  
        }
        


        //Implement hashtables(graphs) of local connections
        //have values of 1s and 0s so that you can determie if a specific local has a pin or not
        //have another graph that has valid moves connections
        //implement a stack of moves that will allow to fetch back moves as well as to write them to the screen 
        //If possible try to add 2 threads that would be looking for a solution that feed their failed results into a list and would capitalize from the list together
    }
}
