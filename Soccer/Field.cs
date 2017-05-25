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
        private List<Rectangle> boxes = new List<Rectangle>();
        public const int width = 50;
        public const int height = 50;
        public bool goal { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public Field()
        {
            X = 0;
            Y = 0;
            goal = false; // determines whether smb scored or not
        }
        public void SetUp()
        {
            int count = 0;
            while(count != 83)
            {
                if(count==11 || count==23 || count == 35 || count == 47 || count == 59 || count == 71)
                {
                    X = 0;
                    Y += 50;
                    boxes.Add(new Rectangle(X, Y, width, height));
                }
                else
                {
                    boxes.Add(new Rectangle(X, Y, width, height));
                    X += 50;
                }              
                count++;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in boxes)
            {
                if(boxes.IndexOf(item) == 23 || boxes.IndexOf(item) == 35 || boxes.IndexOf(item) == 47)
                {
                    spriteBatch.Draw(Net, item, Color.White);
                }
                else if( boxes.IndexOf(item) == 34 || boxes.IndexOf(item) == 46 || boxes.IndexOf(item) == 58)
                {
                    spriteBatch.Draw(Net, item, Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Box, item, Color.White);
                }
                
            }
            
        }
    }
}
