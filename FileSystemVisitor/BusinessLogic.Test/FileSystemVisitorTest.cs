using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace BusinessLogic.Test
{
    public class FileSystemVisitorTests
    {
        private IFileProvider _fileProvider;
        private const string _existingPath = "C://aaa";
        private string[] _directories = new[] { "C://aaa", "C://aaa/a", "C://aaa/b" };
        private string[] _files = new[] { "C://aaa/a11.txt", "C://aaa/a/a11.txt", "C://aaa/b/a1.txt", "C://aaa/b/a2.txt" };

        public FileSystemVisitorTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var fileProviderMock = fixture.Freeze<Mock<IFileProvider>>();

            foreach(var directory in _directories)
            {
                fileProviderMock
                   .Setup(c => c.DirectoryExist(directory))
                   .Returns(true);
            }

            foreach(var file in _files)
            {
                fileProviderMock
                   .Setup(c => c.FileExists(file))
                   .Returns(true);
            }           

            fileProviderMock
                .Setup(c => c.GetDirectories(_existingPath))
                .Returns(new string[] { "C://aaa/a", "C://aaa/b" });

            fileProviderMock
                .Setup(c => c.GetDirectories("C://aaa/a"))
                .Returns(new string[] { });

            fileProviderMock
                .Setup(c => c.GetDirectories("C://aaa/b"))
                .Returns(new string[] { });

            fileProviderMock
              .Setup(c => c.GetFiles(_existingPath))
              .Returns(new string[] { "C://aaa/a11.txt" });

            fileProviderMock
                .Setup(c => c.GetFiles("C://aaa/a"))
                .Returns(new string[] { "C://aaa/a/a11.txt"});

            fileProviderMock
                .Setup(c => c.GetFiles("C://aaa/b"))
                .Returns(new string[] { "C://aaa/b/a1.txt","C://aaa/b/a2.txt" });

            _fileProvider = fileProviderMock.Object;
        }

        [Fact]
        public void GetAllFilesAndDirs_GivenNoFilters_ReturnsAllFiles()
        {
            // Arrange
            var visitor = new FileSystemVisitor(_fileProvider);

            // Act
            var result = visitor.GetAllFilesAndDirs(_existingPath).ToList();

            // Assert
            result.Should().Contain(_files.Concat(_directories));
        }

        [Theory]
        [InlineData("a11")]
        [InlineData("b")]
        public void GetAllFilesAndDirs_GivenFileFilter_ReturnsMatchingItems(string namePart)
        {
            // Arrange
            var visitor = new FileSystemVisitor(_fileProvider, fileFilter:(string s ) => { return s.Contains(namePart); });

            // Act
            var result = visitor.GetAllFilesAndDirs(_existingPath).ToList();

            // Assert
            result.Should().Contain(_files.Concat(_directories).Where(x => Path.GetFileName(x).Contains(namePart)));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        public void GetAllFilesAndDirs_GivenDirectoryFilter_ReturnsMatchingItems(string namePart)
        {
            // Arrange
            var visitor = new FileSystemVisitor(_fileProvider, dirFilter: (string s) => { return s.Contains(namePart); });

            // Act
            var result = visitor.GetAllFilesAndDirs(_existingPath).ToList();

            // Assert
            result.Should().Contain(_files.Concat(_directories).Where(x => Path.GetFileName(x).Contains(namePart)));
        }

        [Fact]
        public void GetAllFilesAndDirs_GivenNonExistentRootPath_ThrowsArgumentException()
        {
            // Arrange
            var visitor = new FileSystemVisitor(_fileProvider);

            // Act
            Action act = () => visitor.GetAllFilesAndDirs("fakepath").ToList();

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
