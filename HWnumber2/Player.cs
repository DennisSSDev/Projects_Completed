using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWnumber2
{
    class Player : GameObject
    {
        private int levelScore;
        private int totalScore;
        public int LevelScore { get { return levelScore; } set { levelScore = value; } }
        public int TotalScore { get { return totalScore; } set { totalScore = value; } }

        public Player(int x, int y, int height, int width, int pTotalScore = 0, int pLevelScore = 0) : base(x, y, height, width)
        {
            this.totalScore = pTotalScore;
            this.levelScore = pTotalScore;
        }
    }
}
