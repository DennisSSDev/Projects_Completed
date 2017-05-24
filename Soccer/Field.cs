using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
namespace Soccer
{
    class Field
    {
        //screen width is 800
        //screen height is 480
        public Texture2D Box { get; set; }
        public Texture2D Net { get; set; }
        public Rectangle rect { get; set; }
        List<Rectangle> boxes = new List<Rectangle>();
        const int width = 50;
        const int height = 50;
        public int X { get; set; }
        public int Y { get; set; }
        public Field()
        {
            boxes.Add(new Rectangle(0, 0, width, height));
        }
        public void SetUp()
        {
            int count = 0;
            while(count != 77)
            {
                //boxes.Add()
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Box, boxes[0], Color.White);
        }
    }
}
