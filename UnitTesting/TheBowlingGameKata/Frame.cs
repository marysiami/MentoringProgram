using System.Collections.Generic;

namespace TheBowlingGameKata
{
    public class Frame
    {
        public int Score { get; set; }
        public List<Roll> Rolls { get; set; }

        public Frame()
        {
            Rolls = new List<Roll>();
        }
    }
}
