using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WorkingHW2
{
    class GameObject
    {
        private Texture2D curTexture;//holds player texture
        private Rectangle position;//holds player size and location
        public Texture2D CurTexture { get { return curTexture; } set { curTexture = value; } }
        public Rectangle Position { get { return position; } set { position = value; } }
        /// <summary>
        /// two properties that help me set the players position, without creating extra Rectangles in the game class
        /// </summary>
        public int X { get { return position.X; } set { position.X = value; } }
        public int Y { get { return position.Y; } set { position.Y = value; } }
        public GameObject(int x, int y, int height, int width)//Constructor
        {
            position.X = x;
            position.Y = y;
            position.Height = height;
            position.Width = width;
        }
        public virtual void Draw(SpriteBatch obj)
        {
            obj.Draw(curTexture, position, Color.White);//separate object for drawing the object
        }
    }
}
