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
        public Rectangle targetObj { get; set; }
        public Texture2D texOfTarget { get; set; }
        Rectangle pos = new Rectangle(50, 50, 50, 50);
        public Target()
        {
            targetObj = pos;
        }


    }
}
