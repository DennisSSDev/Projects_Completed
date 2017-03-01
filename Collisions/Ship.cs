using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collisions
{
    class Ship
    {
        private Texture2D image;
        private Rectangle iSpace;
        private Vector2 direction;

        public Texture2D Image { get { return image; } set { } }
        public Rectangle ISpace { get { return iSpace; } set { iSpace = value; } }
        public Vector2 Direction { get { return direction; } set { direction = value; } }
        public Ship(Texture2D image, Rectangle iSpace, Vector2 direction)
        {
            this.image = image;
            direction.X = 1f;
            direction.Y = 1f;
            this.direction = direction;
            
            this.iSpace = iSpace;
        }





    }
}
