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
        public int[] grid1 { get; set; }
        int[] grid = new int[64];
        string[] lines = new string[8];
        string[] separateLines = new string[64];
        Rectangle[] invalidPositions = new Rectangle[8];
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
        Player player;
        public Player Player { get { return player; } }
        Target tg;
        public Target Target { get { return tg; } }
        object key = new object();
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
            
            newThread = new Thread((one) => { one = tg; player.Move(tg); });

            thread2 = new Thread((one) => { one = player; tg.Move(player); });

            newThread.Start();
            thread2.Start();

            // });
            //  bugsThread.Start();
            newRan = new Random();
           
        }
        public void ReadBoard()
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

                string[] newTemp = item.Split(',');
                int count2 = 0;
                for (int i = count; i < count + 8; i++)
                {
                    separateLines[i] = newTemp[count2];
                    count2++;
                }
                count += 8;
            }
            try
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
        public void startGame(SpriteBatch spriteBatch)
        {
            Player player = new Player(this, new Random());
            Target target = new Target(this, new Random());        
        }
        public void drawBoard(SpriteBatch spriteBatch)
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
                    try
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
        {
            //instead of using 2 rectangles for checking, use one and lock it just so one thread can use it at a time
            Rectangle temp;
            lock (key)
            {
                temp = new Rectangle(obj.X + tempX, obj.Y + tempY, 50, 50);


                foreach (var item in invalidPositions)
                {
                    if (item.Location == temp.Location)
                    {
                        return false;
                    }
                }

                if (temp.X >= 400 || temp.X < 0 || temp.Y >= 400 || temp.Y < 0)
                {
                    return false;
                }
                return true;
            }
        }
        public void StartGame()
        {
            
        } 
    }
}
