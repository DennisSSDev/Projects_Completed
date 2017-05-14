using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW5_SearchingGame
{
    class Target//one of the objects that will be moving around 
    {
        int x = 50;//Starting positions
        int y = 50;
        Random newRan;
        public int X { get { return x; } set { } }//properties of the target
        public int Y { get { return y; } set { } }
        Rectangle size;
        GameBoard gameB;//required gameboard object to check if the moves are valid
        Random num;
        public bool Dead { get; set; } = false;//the target starts off alive 
        public Rectangle targetObj { get; set; }
        public Texture2D texOfTarget { get; set; }
        public Target(GameBoard ex, Random num)//Pass in the gameboard object upon creation and a random number that
            //will determine where the object will move and for how long will it sleep
        {
            size = new Rectangle(x, y, 50, 50);
            targetObj = size;
            gameB = ex;
            this.num = num;
            newRan = num;
        }
        public void Move(Player pl)//allows the target to move around the board unto allowed positions 
            //and check whether it collides with the player
        {
            object temp = new object();
            
            
                lock (temp)//redundant lock, but it's ok
                {
                while (this.X != pl.X || this.Y != pl.Y)//until we hit the player we will move continuosly
                {



                    int tempX = 0;
                    int tempY = 0;
                    int ran = newRan.Next(300, 501);

                    Thread.Sleep(ran);

                    int ran2 = newRan.Next(0, 8);//determination of where the target goes
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

                    if (gameB.ValidPosition(tempX, tempY,this.targetObj))//validation of the move 
                    {
                        this.x += tempX;
                        this.y += tempY;
                        targetObj = new Rectangle(x, y, 50, 50);
                    }
                    if (this.X == pl.X && this.Y == pl.Y)//if we are on the same spot as the player we win
                    {
                        Dead = true;
                        break;
                    }
                }
                }
        }
        public void DrawTarget(SpriteBatch spriteBatch)//draw method that makes my life easier
        {
            spriteBatch.Draw(texOfTarget, targetObj, Color.White);

        }


    }
}
