using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soccer
{
    class GoalKeeper
    {
        //properties
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public Rectangle rectGoalKeeper { get; set; }
        public Texture2D goalKTex { get; set; }

        //private variables
        private Random objRan;
        private int moveCount = 0;
        private float saverRate = 100f;
        private Field objField;
        public GoalKeeper()
        {
            objRan = new Random();
            objField = new Field();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(goalKTex, rectGoalKeeper, Color.White);
        }

        public int GoalKMove()
        {
                if (moveCount < 0)
                {
                moveCount++;
                return 50;
                    
                }
                else if(moveCount > 0)
                {
                    
                    moveCount--;
                return -50;
                }
                else if(moveCount == 0)
                {
                    int retain = objRan.Next(0, 2);//determines whether goalkeeper runs up or down
                    if(retain == 0)
                    {
                        
                        moveCount++;
                    return 50;
                    }
                    else
                    {
                        
                        moveCount--;
                    return -50;
                    }
                }
            else
            {
                return 0;
            }
                
            
        }
        public void Save(Ball obj)//FOR NOW LET IT BE PRIMITIVE, stretch goal is to enable skill/failure
        {
            if (this.rectGoalKeeper.Intersects(obj.ballSizing))
            {
                if(this.X1+100>= 550)//if the goalkeeper is on the right side bounce the ball back into a random position on the grid
                {
                    //for x it can be from 300 to 500
                    //for y it can be from 0 to 300
                    //exceptions are x: 500 y: 100,150,200
                    obj.X1 -= objRan.Next(50, 201);
                    obj.Y1 -= objRan.Next(0, 301);
                }
                else//same thing but in the opposite direction
                {
                    obj.X1 += objRan.Next(50, 201);
                    obj.Y1 += objRan.Next(0, 301);
                }
            }
        }
        //these players don't move around, only thing they have is a percentage of saving a ball
        //if they successfully save the ball it should bounc away in a random direction
        //the more saves they make their skill of saving the ball should either go up or down

    }
}
