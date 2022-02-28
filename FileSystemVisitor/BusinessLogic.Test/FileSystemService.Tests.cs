using Autofac.Extras.Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace BusinessLogic.Test
{
    public class FileSystemServiceTests
    {
        public static IEnumerable<object[]> Data =>
          new List<object[]>
          {
            new object[] {"C://aaa", null, null},
            new object[] { "C://aaa", "f*", null },
            new object[] {"C://aaa", "f*", SearchOption.AllDirectories},
            new object[] { "C://aaa", "f*", SearchOption.TopDirectoryOnly},
            new object[] {"C://aaa", null, SearchOption.AllDirectories},
          };

        [Fact]
        public void GetFilesInfo_ThrowFileNotFoundException_EmptyString()
        {
            var service = new FileSystemService();

            var list = new string[1];

            list[0] = string.Empty;

            Assert.Throws<FileNotFoundException>(()=> service.GetFilesInfo(list).ToList());
        }

        [Fact]
        public void GetFilesInfo_GetTheSameFullName()
        {            
            var service = new FileSystemService();

            var list = new string[1];

            list[0] = "C://aaa";

            var expect = new FileInfo(list[0]).FullName;

            var actual = service.GetFilesInfo(list).ToList()[0].FullName;

            Assert.Equal(expect,actual);
        }
    
        [Theory]
        [InlineData("C://aaa",null)]
        [InlineData("C://aaa", "f*")]
        public void GetFiles_CheckedSearchPattern(string path, string searchPattern)
        {
            var files = new string[] { "file1.txt", "file2.txt", "file3.txt" };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IFileProvider>().Setup(x => x.GetFiles(path, searchPattern))
                    .Returns(files);

                mock.Mock<IFileProvider>().Setup(x => x.GetFiles(path))
                   .Returns(files);

                var cls = mock.Create<FileSystemService>();
                
                var actual = cls.GetFiles(path, searchPattern);

                Assert.True(actual != null);

                Assert.Equal(files.Count(),actual.Count());
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void GetDirectories_CheckedSearchPattern(string path, string searchPattern, SearchOption searchOption)
        {
            var files = new string[] { "C://aaa/a", "C://aaa/b", "C://aaa/c"};

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IFileProvider>().Setup(x => x.GetDirectories(path, searchPattern, searchOption))
                    .Returns(files);

                mock.Mock<IFileProvider>().Setup(x => x.GetDirectories(path))
                   .Returns(files);

                var cls = mock.Create<FileSystemService>();

                var actual = cls.GetDirectories(path, searchPattern, searchOption);

                Assert.True(actual != null);

                Assert.Equal(files.Count(), actual.Count());
            }            

        }
        
    }
}
