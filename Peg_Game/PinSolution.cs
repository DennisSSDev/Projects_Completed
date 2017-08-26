using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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

        Stack<Pins> removedPinsStack = new Stack<Pins>();
        Stack<Pins> movedPins = new Stack<Pins>();
        Dictionary<Pins, List<Pins>> ignorableMoves = new Dictionary<Pins, List<Pins>>();
        Dictionary<int, Dictionary<Pins, List<Pins>>> turn_to_Unusable_Move = new Dictionary<int, Dictionary<Pins, List<Pins>>>();
        Dictionary<Pins, Pins> planter = new Dictionary<Pins, Pins>();

        private int turn_count = 0;
        private int winCount = 0;
        private int removedPins = 1;
        private int counter = 0;
        string movesList = null;
        private bool made_move = false;
        private int itirations = 0;
        public bool SolutionDone { get; set; }

        bool found_unusable_move = false;//make sure to make it false again aftre found

        public PinSolution()
        {
            SolutionDone = false;
            //add all the pins to a single data struct
            allPins.Add(new Pins() { PinNum = 0, HasPin = false, Visited = false, Usable = true });//if a pin exists at the spot it has a letter N, if not it has letter E
            allPins.Add(new Pins() { PinNum = 1, HasPin = true, Visited = false, Usable = true});
            allPins.Add(new Pins() { PinNum = 2, HasPin = true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 3, HasPin = true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 4, HasPin = true, Visited = false, Usable = true});
            allPins.Add(new Pins() { PinNum = 5, HasPin = true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 6, HasPin= true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 7, HasPin = true, Visited = false, Usable = true});
            allPins.Add(new Pins() { PinNum = 8, HasPin= true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 9, HasPin= true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 10,HasPin = true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 11, HasPin = true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 12, HasPin= true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 13, HasPin  = true, Visited = false, Usable = true });
            allPins.Add(new Pins() { PinNum = 14, HasPin = true, Visited = false, Usable = true });

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
            memberConnections.Add(5, connections5);
            memberConnections.Add(6, connections6);
            memberConnections.Add(7, connections7);
            memberConnections.Add(8, connections8);
            memberConnections.Add(9, connections9);
            memberConnections.Add(10, connections10);
            memberConnections.Add(11, connections11);
            memberConnections.Add(12, connections12);
            memberConnections.Add(13, connections13);
            memberConnections.Add(14, connections14);
        }
        private string AddText(string given, int a, int b)
        {
            given += "From " + a + " to " + b + "\r\n";
            return given;
        }
        private string RemoveText(string given)
        {
            if (given == null)
                return given;
            else
                return given.Remove(given.Length-15, 12);
        }

        private void Reset(int nextEmptyPin)
        {
            removedPins = 1;
            nextEmptyPin++;
            foreach (var item in allPins)
            {
                item.HasPin = true;
            }
            allPins[nextEmptyPin].HasPin = false;
        }
        private void Reverse()//this method will be called when the solution gets stuck and needs to go back
            //Rework the ignorable moves so that they interact with the last index in the list
        {
            movesList = RemoveText(movesList);
            int temp = ignorableMoves[movedPins.Peek()].Count-1;
            allPins[ignorableMoves[movedPins.Peek()][temp].PinNum].HasPin = false;//need to remove the guy with the last index
            allPins[movedPins.Peek().PinNum].HasPin = true;
            allPins[removedPinsStack.Peek().PinNum].HasPin = true;
            /*if (turn_to_Unusable_Move.Values == null)
            {
                planter.Add(movedPins.Peek(), ignorableMoves[movedPins.Peek()][ignorableMoves.Count-1]);//last index
                turn_to_Unusable_Move.Add(turn_count, planter);
                turn_count--;
                ignorableMoves[movedPins.Peek()].RemoveAt(temp);//DO I need to remove the move that was made from the ignorable moves list
                movedPins.Pop();
                removedPinsStack.Pop();              
                return;
            }  */ 
            if (turn_to_Unusable_Move.ContainsKey(turn_count))
            {
                if (turn_to_Unusable_Move[turn_count].ContainsKey(movedPins.Peek()))
                    turn_to_Unusable_Move[turn_count][movedPins.Peek()].Add(ignorableMoves[movedPins.Peek()][temp]);
                else
                {
                    turn_to_Unusable_Move[turn_count].Add(movedPins.Peek(), new List<Pins>());
                    turn_to_Unusable_Move[turn_count][movedPins.Peek()].Add(ignorableMoves[movedPins.Peek()][temp]);
                }                //last index
            }
            else
            {
                turn_to_Unusable_Move.Add(turn_count, new Dictionary<Pins, List<Pins>>());
                turn_to_Unusable_Move[turn_count].Add(movedPins.Peek(),new List<Pins>());//Looks like there could also be the same movedPins keys --> fix
                turn_to_Unusable_Move[turn_count][movedPins.Peek()].Add(ignorableMoves[movedPins.Peek()][temp]);
            }
            ignorableMoves.Remove(movedPins.Peek());//You need to reverse the last move in the index
            movedPins.Pop();
            removedPinsStack.Pop();
            turn_count--;//doesn't help the algorithm find the last move for some reason ---> main problem to fix
            removedPins--;
            itirations = 0;
            //go back to the DepthFirstSearch method as you need to check with the turnn_to_Unusable_Move to make sure whether you tried that move already
            //check the ones that are visited
            //check the stack of latest moves(ignorable moves)
            //set that specific pin to not be usable
            //remove the last move from the stak
            //once you've ignored that move and tried another move, it should be considered usable again
            //or you can always keep a count of what move that was with the moves done and say if the specific move is $ and the pin 1 to pin 2 was bad - record it and use it for later comparison
        }
        private void DepthFirstSearch(int winCount)
        {
            if (winCount > counter)
            {
                Reset(winCount);
            }
            counter = winCount;
            while (removedPins != 14)
            {
                int temp = -1;
                made_move = false;
                if (itirations > 14)
                {
                    Reverse();//you got stuck trying to solve the problem, and now you need to find a new solution
                }
                foreach (var item in memberConnections)
                {
                    if (allPins[item.Key].HasPin == false)
                    {
                        itirations++;
                        continue;
                    }
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        found_unusable_move = false;
                        temp = (allPins[item.Value[i]].PinNum + item.Key) / 2;
                        if (allPins[temp].HasPin == false || allPins[item.Value[i]].HasPin == true)
                        {
                            continue;
                        }

                        if (turn_to_Unusable_Move.ContainsKey(turn_count))
                        {
                         if (turn_to_Unusable_Move[turn_count].ContainsKey(allPins[item.Key]) &&
                             turn_to_Unusable_Move[turn_count][allPins[item.Key]].Contains(allPins[item.Value[i]]))
                            {
                              found_unusable_move = true;
                            }
                            
                            if (found_unusable_move)
                            {
                                found_unusable_move = false;
                                continue;
                            }
                        }
                        allPins[item.Value[i]].HasPin = true;
                        allPins[item.Value[i]].Visited = true;
                        allPins[item.Key].HasPin = false;
                        allPins[temp].HasPin = false;
                        removedPins++;
                        movedPins.Push(allPins[item.Key]);
                        removedPinsStack.Push(allPins[temp]);
                        if (ignorableMoves.ContainsKey(allPins[item.Key]))
                            ignorableMoves[allPins[item.Key]].Add(allPins[item.Value[i]]);
                        else
                        {
                            ignorableMoves.Add(allPins[item.Key], new List<Pins>());
                            ignorableMoves[allPins[item.Key]].Add(allPins[item.Value[i]]);//will occur that there could be the same keys --> in that case you need to add the moves to the same key(list most likely)
                        }
                        movesList = AddText(movesList, allPins[item.Key].PinNum, allPins[item.Value[i]].PinNum);
                        made_move = true;
                        turn_count++;
                        break;
                            //make sure you exit out of here as soon as this happnes and start the search again
                            //if you get stuck you have 2 stacks that tell you which moves should be ignored (actually if you do revert your moves, create a new  stack of reverted moves to know for sure to not use that specific move again
                       
                    }
                    if (made_move == false)
                    {
                        itirations++;
                    }
                    else
                    {
                        itirations = 0;
                        break;
                    }
                    
                }
            }
            //end of main loop, don't go below until the general algorithm is implemented



            //at the end whent the loop is done add the win count
            winCount++;
            ignorableMoves.Clear();
            turn_to_Unusable_Move.Clear();
            movedPins.Clear();
            removedPinsStack.Clear();
            planter.Clear();
            
        }

        public void PlayGame()
        {
            DepthFirstSearch(winCount);
            if(winCount == 15)
            {
                SolutionDone = true;
                return;
            }
            //else uncomment this out as soon as you find the inf loop error inside the DepthFirsSearch
            //{
            //  winCount++;
            //PlayGame();
            //}
            SolutionDone = true;
            return;    
        }
        public string GetFullSolution()
        {
            return movesList;
        }
        //Implement hashtables(graphs) of local connections
        //have values of 1s and 0s so that you can determie if a specific local has a pin or not
        //have another graph that has valid moves connections
        //implement a stack of moves that will allow to fetch back moves as well as to write them to the screen 
        //If possible try to add 2 threads that would be looking for a solution that feed their failed results into a list and would capitalize from the list together
    }
}
