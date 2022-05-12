using FluentAssertions;
using System;
using Xunit;

namespace CalculatorKata.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_GetEmptyString_ReturnZero()
        {
            // Arrange
            var word = string.Empty;

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void Add_GetStringWithOneValue_ReturnStringNumber()
        {
            // Arrange
            var word = "1";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(1);
        }


        [Fact]
        public void Add_GetStringWithTwoValues_ReturnSum()
        {
            // Arrange
            var word = "1,2";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Add_GetWrongString_ReturnZero()
        {
            // Arrange
            var word = "aaa,77";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void Add_GetLongString_ReturnSum()
        {
            // Arrange
            var word = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(22);
        }

        [Fact]
        public void Add_GetStringWithCommasAndNewLine_ReturnSum()
        {
            // Arrange
            var word = ".\n1.2.3\n...";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(6);
        }

        [Fact]
        public void Add_GetStringWithDelimter_ReturnSum()
        {
            // Arrange
            var word = ";\n1;2";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Add_GetStringWithNegativeNumber_ThrowException()
        {
            // Arrange
            var word = "1,2,-2,-1,5";

            // Act
            Action act = () => Calculator.Add(word);

            // Assert
            act.Should().Throw<Exception>();
        }
    }
}
