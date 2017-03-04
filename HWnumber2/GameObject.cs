using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HWnumber2
{
    class GameObject
    {
        private Texture2D curTexture;
        private Rectangle position;
        public Texture2D CurTexture { get { return curTexture; } set { } }
        public Rectangle Position { get { return position; } set { position = value; } }

        public int X { get { return position.X; } set { position.X = value;  } }
        public int Y { get {return position.Y; } set { position.Y = value; } }



        public GameObject(int x, int y, int height, int width)
        {
            position.X = x;
            position.Y = y;
            position.Height = height;
            position.Width = width;
        }

        public virtual void Draw(SpriteBatch obj)
        {
            obj.Draw(curTexture, position, Color.White);
        }
    }
}
