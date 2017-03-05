using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace WorkingHW2
{
    class Player : GameObject
    {
        private int levelScore;//attribute that holds players score 
        private int totalScore;//attriute that holds player's absolute score
        public int LevelScore { get { return levelScore; } set { levelScore = value; } }
        public int TotalScore { get { return totalScore; } set { totalScore = value; } }
        public Player(int x, int y, int height, int width, int pTotalScore = 0, int pLevelScore = 0) : base(x, y, height, width)//constructor inheriting from game object
        {
            this.totalScore = pTotalScore;
            this.levelScore = pTotalScore;
        }
    }
}
