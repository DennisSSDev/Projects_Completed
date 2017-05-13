using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace HW5_SearchingGame
{
    class Player
    {
        public Game1 game1;
        Random newRan;
        GameBoard gameB;
        int x = 50;
        int y = 250;
        public int X { get { return x; } set { } }
        public int Y { get { return y; } set { } }
        Rectangle size;
        public Rectangle playerObj { get; set; }
        public Texture2D image { get; set; }
        public Player()
        {
            size = new Rectangle(x, y, 50, 50);
            newRan = new Random();
            gameB = new GameBoard();
            playerObj = size;
            
        }

        public void Move(Target tg)
        {
            int tempX = 0;
            int tempY = 0;
            if (this.X == tg.targetObj.X && this.Y == tg.targetObj.Y)
            {
                game1.Exit();
            }
            int ran = newRan.Next(250, 351);
            Thread.Sleep(ran);
            int ran2 = newRan.Next(0, 8);
            switch (ran2)
            {
                case 0:  tempX += 50;
                    break;
                
                case 1: tempX -= 50;
                    break;
                case 2: tempY += 50;
                    break;

                case 3: tempY -= 50;
                    break;

                case 4: tempX += 50;
                    tempY += 50;
                    break;

                case 5: tempX -= 50;
                    tempY -= 50;
                    break;

                case 6: tempX -= 50;
                    tempY += 50;
                    break;

                case 7: tempX += 50;
                    tempY -= 50;
                    break;
                default:
                    break;
            }
            if (gameB.ValidPosition())
            {
                this.X += tempX;
                this.Y += tempY;
            }


        }
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, playerObj, Color.White);

        }

    }
}
