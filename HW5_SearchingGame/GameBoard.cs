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
        Rectangle[] invalidPositions = new Rectangle[4];
        int countForInvalid = 0;
        const int xInit = 0;
        int x = 0;
        const int yInit = 0;
        int y = 0;
        object one = new object();
        object two = new object();
        Random newRan;
        Rectangle box = new Rectangle(-10, 0, 75, 75);
        Rectangle[] boxes = new Rectangle[64];
        Texture2D rectBox;
        Player player;
        Target tg;
        Thread newThread;
        Thread thread2;
        public Texture2D Texture { get; set; }
        bool allow = true;
        public GameBoard()
        {
            player = new Player(this, new Random());
            tg = new Target(this, new Random());
            //Thread bugsThread = new Thread((object obj) =>
            // {

            //   obj = tg;
            
            newThread = new Thread((one) => { one = tg; player.Move(tg); });

            thread2 = new Thread((two) => { two = player; tg.Move(player); });

            

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
           
            
            
        }
        public void drawBoard(SpriteBatch spriteBatch)
        {
            ReadBoard();
            if (allow)
            {
                for (int i = 0; i < 64; i++)
                {
                    if (i == 8 || i == 16 || i == 24 || i == 32 || i == 40
                        || i == 48 || i == 56)
                    {
                        x = xInit;
                        y += 50;
                    }
                    boxes[i] = new Rectangle(x, y, 50, 50);
                    x += 50;

                }
            }
            allow = false;
            int count1 = 0;

            Color colorSum = new Color();
            foreach (var item in grid1)
            {
                if (item == 1)
                {
                    colorSum = Color.Gray;
                    invalidPositions[countForInvalid] = boxes[count1];
                }
                else
                {
                    colorSum = Color.White;
                }
                spriteBatch.Draw(Texture, boxes[count1], colorSum);
                count1++;
            }
            
        }


        public bool ValidPosition()
        {
            foreach (var item in invalidPositions)
            {
                if(item.X == player.X && item.Y == player.Y)
                {
                    return false;
                }
            }
            if (player.X > 400 || player.X < 0 || player.Y > 400 || player.Y < 0)
            {
                return false;
            }
            return true;
        }
        public void StartGame()
        {
            newThread.Start();
            thread2.Start();
        } 
    }
}
