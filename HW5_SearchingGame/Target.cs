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
    class Target
    {
        int x = 50;
        int y = 50;
        public Game game1;
        Random newRan;
        public int X { get { return x; } set { } }
        public int Y { get { return y; } set { } }
        Rectangle size;
        GameBoard gameB;
        Random num;
        public Rectangle targetObj { get; set; }
        public Texture2D texOfTarget { get; set; }
        public Target(GameBoard ex, Random num)
        {
            size = new Rectangle(x, y, 50, 50);
            targetObj = size;
            gameB = ex;
            this.num = num;
            newRan = num;
        }
        public void Move(Player pl)
        {
            int tempX = 0;
            int tempY = 0;

            if (this.X == pl.X && this.Y == pl.Y)
            {
                game1.Exit();
            }


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

            if (gameB.ValidPosition())
            {
                this.X += tempX;
                this.Y += tempY;
            }




        }
        public void DrawTarget(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texOfTarget, targetObj, Color.White);

        }


    }
}
