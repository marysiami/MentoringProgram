using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Add_GetWrongString_ReturnException()
        {
            // Arrange
            var word = "aaa,77";

            // Act
            var result = Calculator.Add(word);

            // Assert
            result.Should().Be(0);
        }
    }
}
