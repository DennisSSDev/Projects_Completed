using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace HWnumber2
{
    class Collectible : GameObject
    {
        private bool activeView = true;
        public bool ActiveView { get { return activeView; } set { activeView = value; } }
        public Collectible(int x, int y, int height, int width, bool activeView = true) : base(x, y, height, width)
        {
            this.activeView = activeView;
        }
        public bool CheckCollision(GameObject obj)
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
        public override void Draw(SpriteBatch obj)
        {
            if (activeView)
            {
                base.Draw(obj);
            }
        }
    }
}
