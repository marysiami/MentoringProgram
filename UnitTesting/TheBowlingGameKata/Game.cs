using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBowlingGameKata
{
    public class Game
    {
        public Frame[] Frames { get; set; }
        private int score = 0;

        public Game()
        {
            Frames = new Frame[10];
        }

        public void Roll(int pins)
        {
            score += pins;
        }

        public int Score()
        {
            return score;
        }
    }
}
