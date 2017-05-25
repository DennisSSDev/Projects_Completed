using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soccer
{
    class Ball: Field
    {
        //object that will be moved around by passes, shots and moves that happen with the player
        //Attach the object to the player that moves and move the ball together with the player
        //Upon shooting the ball it should bounce in a random direction of the goalkeeper 
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public Rectangle ballSizing { get; set; }
        public Texture2D ballTexture { get; set; }
        public Ball():
            base()
        {
            X1 = 250;
            Y1 = 150;
            ballSizing = new Rectangle(this.X1, this.Y1, Field.width, Field.height);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ballTexture, ballSizing, Color.White); 
        }

    }
}
