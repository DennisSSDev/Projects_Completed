using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace HW5_SearchingGame
{
    class GameBoard
    {
        /// <summary>
        /// This class allows to read in the board and determine where should the blocks be drawn 
        /// Starts the threads and basically runs the game
        /// Determines what is a valid/invalid move
        /// </summary>
        public int[] grid1 { get; set; }//property for the grid system of blocks
        int[] grid = new int[64];//actual grid
        string[] lines = new string[8];//will be used to read each line from the given file
        string[] separateLines = new string[64];//each number separated from the lines array
        Rectangle[] invalidPositions = new Rectangle[8];//collects all the invalid squares (not bounds of the screen)
        int countForInvalid = 0;
        const int xInit = 0;
        int x = 0;
        const int yInit = 0;
        int y = 0;
        object one = new object();
        object two = new object();
        Random newRan;
        Random newRan2;
        Rectangle box = new Rectangle(-10, 0, 75, 75);
        Rectangle[] boxes = new Rectangle[64];
        Player player;//create the player object for starting thread
        public Player Player { get { return player; } }
        Target tg;//create the target object to start his thread
        public Target Target { get { return tg; } }
        object key = new object();//object that will allow us to lock the movement of the thread in the move determination method
        Thread newThread;
        Thread thread2;
        public Texture2D Texture { get; set; }
        bool allow = true;
        public GameBoard()
        {
            newRan = new Random();
            newRan2 = new Random();
            player = new Player(this, newRan);
            tg = new Target(this, newRan2);
            //Thread bugsThread = new Thread((object obj) =>
            // {

            //   obj = tg;
            //Creating and starting the threads
            newThread = new Thread((one) => { one = tg; player.Move(tg); });

            thread2 = new Thread((one) => { one = player; tg.Move(player); });
            try//abort threads if smth wrong occurs
            {
                newThread.Start();
                thread2.Start();
            }
            catch (Exception)
            {
                newThread.Abort();
                thread2.Start();
                
            }
            

            // });
            //  bugsThread.Start();
            newRan = new Random();
           
        }
        public void ReadBoard()//method that allows us to create the board based on the read file
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("board.csv"))
            {

                /*while(reader.ReadLine() != null)
                {
                    lines[count] = reader.ReadLine();
                    count++;
                }*/
                for (int i = 0; i < 8; i++)
                {
                    lines[i] = reader.ReadLine();
                }
            }
            foreach (var item in lines)
            {

                string[] newTemp = item.Split(',');//allows us to read each member of the board separately
                int count2 = 0;
                for (int i = count; i < count + 8; i++)
                {
                    separateLines[i] = newTemp[count2];
                    count2++;
                }
                count += 8;
            }
            try//in case we find a faulty member(null or smth that we can't convert) wit finds the ecxeption and writes it out
            {
                for (int i = 0; i < 64; i++)
                {
                    bool trueORFalse = int.TryParse(separateLines[i], out grid[i]);
                    if (trueORFalse == false)
                    {
                        throw new Exception();
                    }
                    grid1 = grid;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void startGame(SpriteBatch spriteBatch)//a redundant method PS: Steve said it's ok to not use it
        {
            Player player = new Player(this, new Random());
            Target target = new Target(this, new Random());        
        }
        public void drawBoard(SpriteBatch spriteBatch)//We now create the board visually
        {
            ReadBoard();
            if (allow)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    boxes[i] = new Rectangle(x, y, 50, 50);
                    if (i == 7 || i == 15 || i == 23 || i == 31 || i == 39
                        || i == 47 || i == 55)
                    {
                        x = xInit;
                        y += 50;
                    }
                    else
                    {
                        
                        x += 50;
                    }

                }
            }
            allow = false;
            int count1 = 0;

            Color colorSum = new Color();
            foreach (var item in grid)
            {
                if (item == 1)
                {
                    try//catch any errors in the process
                    {
                        colorSum = Color.Gray;
                        invalidPositions[countForInvalid] = boxes[count1];
                        countForInvalid++;
                    }
                    catch (Exception)
                    {

                        Debug.WriteLine("error");
                    }
                        
                     
                }
                else
                {
                    colorSum = Color.White;
                }
                spriteBatch.Draw(Texture, boxes[count1], colorSum);
                count1++;
            }
            
        }


        public bool ValidPosition(int tempX,int tempY, Rectangle obj)//pass in one rectangle and see if it will change anything,should work
        {//Valifdation of each move that the threads make happens here
            //instead of using 2 rectangles for checking, use one and lock it just so one thread can use it at a time
            Rectangle temp;
            lock (key)
            {
                temp = new Rectangle(obj.X + tempX, obj.Y + tempY, 50, 50);


                foreach (var item in invalidPositions)
                {
                    if (item.Location == temp.Location)//if the temp position is inside a grey box, it won;t allow to use that move
                    {
                        return false;
                    }
                }

                if (temp.X >= 400 || temp.X < 0 || temp.Y >= 400 || temp.Y < 0)//if the temp move goes outside the 
                    //boudning box region, don't allow the move
                {
                    return false;
                }
                //for every other occasion allow the move
                return true;
            }
        }
    }
}
