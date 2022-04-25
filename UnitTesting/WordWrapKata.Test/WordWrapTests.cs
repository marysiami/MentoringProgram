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
        public void Wrap_GetLeghtShorterThanCol_ReturnsTheSameTerm()
        {
            // Arrange
            var word = "this";

            // Act
            var act = WordWrap.Wrap(word, 10);

            // Assert
            act.Should().Be(word);
        }

        [Fact]
        public void Wrap_GetOneWordAndSplit_ReturnsGoodString()
        {
            // Arrange
            var word = "word";

            // Act
            var result = WordWrap.Wrap(word, 2);

            // Assert
            result.Should().Be("wo\nrd");
        }

        [Fact]
        public void Wrap_GetOneWordAndSplitManyTimes_ReturnsGoodString()
        {
            // Arrange
            var word = "abcdefghijk";

            // Act
            var result = WordWrap.Wrap(word, 3);

            // Assert
            result.Should().Be("abc\ndef\nghi\njk");
        }

        [Fact]
        public void Wrap_ReplaceSpace_ReturnsGoodString()
        {
            // Arrange
            var word = "word word";

            // Act
            var result = WordWrap.Wrap(word, 5);

            // Assert
            result.Should().Be("word\nword");
        }
    }
}
