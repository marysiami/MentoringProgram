using FluentAssertions;
using System;
using Xunit;

namespace WordWrapKata.Test
{
    public class WordWrapTests
    {
        [Fact]
        public void Wrap_GetEmptyString_ReturnsError()
        {
            // Arrange
            var word = string.Empty;

            // Act
            Action act = () => WordWrap.Wrap(word,1);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Wrap_GetLeghtShorterThanCol_ReturnsError()
        {
            // Arrange
            var word = "this";

            // Act
            Action act = () => WordWrap.Wrap(word, 10);

            // Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Wrap_GetTwoWordsWithSpace_ReturnsWrongString()
        {
            // Arrange
            var word = "word word";

            // Act
            var result =  WordWrap.Wrap(word, 6);

            // Assert
            result.Should().NotBe("word\nword");
        }

        [Fact]
        public void Wrap_GetThreeWordsWithSpace_ReturnsWrongString()
        {
            // Arrange
            var word = "word word word";

            // Act
            var result = WordWrap.Wrap(word, 11);

            // Assert
            result.Should().NotBe("word\nword\nword");
            result.Should().Be("word word\nword");
        }
    }
}
