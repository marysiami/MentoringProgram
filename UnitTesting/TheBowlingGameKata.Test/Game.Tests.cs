using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheBowlingGameKata.Test
{
    public class GameTests
    {
        Game game { get; set; }
        public GameTests()
        {
            game = new Game();
        }

        [Fact]
        public void Roll_GetAllZeros_ReturnZero()
        {
            // Arrange
            var value = 0;
            var n = 10;

            // Act
            RollMany(value, n);

            // Assert
            game.Score().Should().Be(value);
        }

        [Fact]
        public void Roll_GetAllOnes_ReturnSum()
        {
            // Arrange
            var value = 1;
            var n = 20;

            // Act
            RollMany(value, n);

            // Assert
            game.Score().Should().Be(n);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        } 
    }
}
