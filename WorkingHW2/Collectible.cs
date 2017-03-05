using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WorkingHW2
{
    class Collectible : GameObject
    {
        private bool activeView = true;//bool that determines if the collectible is visible or not 
        public bool ActiveView { get { return activeView; } set { activeView = value; } }
        public Collectible(int x, int y, int height, int width, bool activeView = true) : base(x, y, height, width)//constructor that inherits from GameObject
        {
            this.activeView = activeView;
        }
        public bool CheckCollision(GameObject obj)//Collision checker that returns true if the object collides with a game object 
        {
            if (activeView)
            {
                if (obj.Position.Intersects(this.Position))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override void Draw(SpriteBatch obj)//Draw method that will only draw the collectible if it's active 
        {
            if (activeView)
            {
                base.Draw(obj);
            }
        }
    }
}
