using FluentAssertions;
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

        [Fact]
        public void Roll_GetOneSpare_ReturnScore()
        {
            // Act
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);

            // Assert
            game.Score().Should().Be(16);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        [Fact]
        public void Roll_GetOneStrike_ReturnScore()
        {
            // Act
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);

            // Assert
            game.Score().Should().Be(24);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }
    }
}
