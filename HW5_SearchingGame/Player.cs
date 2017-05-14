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
        /// <summary>
        /// Most of the methods/attributes/constructor are similar to the target, I will only comment 
        /// on the stuff that is different 
        /// </summary>
        Random newRan;
        GameBoard gameB;
        int x = 50;//Starting position is right below the target
        int y = 250;
        public int X { get { return x; } set { } }
        public int Y { get { return y; } set { } }
        public bool dead { get; set; } = false;
        Rectangle size;
        public Rectangle playerObj { get; set; }
        public Texture2D image { get; set; }
        public Player(GameBoard ex, Random ran)//Make a parametized constructor to pass in the board to not get a stack overflow
        {
            size = new Rectangle(x, y, 50, 50);
            newRan = ran;
            gameB = ex;
            
            playerObj = size;
            
        }

        public void Move(Target tg)
        {
            object newObj = new object();
            
                lock (newObj)
                {
                while (this.X != tg.X || this.Y != tg.Y)
                {



                    int tempX = 0;
                    int tempY = 0;
                    int ran = newRan.Next(250, 351);
                    Thread.Sleep(ran);
                    int ran2 = newRan.Next(0, 8);
                    switch (ran2)
                    {
                        case 0:
                            tempX += 50;
                            break;

                        case 1:
                            tempX -= 50;
                            break;
                        case 2:
                            tempY += 50;
                            break;

                        case 3:
                            tempY -= 50;
                            break;

                        case 4:
                            tempX += 50;
                            tempY += 50;
                            break;

                        case 5:
                            tempX -= 50;
                            tempY -= 50;
                            break;

                        case 6:
                            tempX -= 50;
                            tempY += 50;
                            break;

                        case 7:
                            tempX += 50;
                            tempY -= 50;
                            break;
                        default:
                            break;
                    }

                    if (gameB.ValidPosition(tempX, tempY, this.playerObj))
                    {
                        this.x += tempX;
                        this.y += tempY;
                        playerObj = new Rectangle(x, y, 50, 50);
                    }
                    if (this.X == tg.X && this.Y == tg.Y)
                    {
                        dead = true;
                        break;
                    }
                }
                    
                
            }
            


        }
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, playerObj, Color.White);

        }

    }
}
