//using Autofac.Extras.Moq;
//using System.Collections.Generic;
//using System.IO;
//using Xunit;

//namespace BusinessLogic.Test
//{
//    public class FileSystemServiceEventsTests
//    {
//        #region Data
//        public static IEnumerable<object[]> Data =>
//       new List<object[]>
//       {
//            new object[] {"C://aaa", new Filter(0)},
//            new object[] { "C://aaa", null}
//       };

//        public static IEnumerable<object[]> FilteredData =>
//        new List<object[]>
//        {
//            new object[] { "C://aaa", new Filter(0)},
//            new object[] { "C://aaa", new Filter(0, "C*", SearchOption.AllDirectories, null) },
//            new object[] { "C://aaa", new Filter(0, "C*", SearchOption.AllDirectories, "C*") },
//            new object[] { "C://aaa", new Filter(0, "C*", SearchOption.TopDirectoryOnly, "C*") },
//            new object[] { "C://aaa", new Filter(0, null, SearchOption.TopDirectoryOnly, "C*") },
//            new object[] { "C://aaa", new Filter(0, null, SearchOption.TopDirectoryOnly, null) }
//        };
//        #endregion

//        #region GetFilesTree

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilesTree_OneEventInvoked_StartedEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                      .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.StartedEvent += delegate (object sender, string e)
//                {
//                    receivedEvents.Add(e);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilesTree, path, filter);

//                Assert.Single(receivedEvents);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilesTree_OneEventInvoked_FinishedEvent(string path, Filter filter)
//        {

//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.FinishedEvent += delegate (object sender, string e)
//                {
//                    receivedEvents.Add(e);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilesTree, path, filter);

//                Assert.Single(receivedEvents);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilesTree_NoEventsInvoked_FileFoundEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.FileFoundEvent += delegate (object sender, TreeNode e)
//                {
//                    receivedEvents.Add(e.FileName);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilesTree, path, filter);

//                Assert.Empty(receivedEvents);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilesTree_SomeEventsInvoked_FileFoundEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                mock.Mock<IFileProvider>().Setup(x => x.GetFiles(path))
//                         .Returns(new string[] { "file1.txt", "file2.txt", "file3.txt" });

//                var cls = mock.Create<FileSystemService>();

//                cls.FileFoundEvent += delegate (object sender, TreeNode e)
//                {
//                    receivedEvents.Add(e.FileName);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilesTree, path, filter);

//                Assert.Equal(3, receivedEvents.Count);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilesTree_OneEventInvoked_DirectoryFoundEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.DirectoryFoundEvent += delegate (object sender, string e)
//                {
//                    receivedEvents.Add(e);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilesTree, path, filter);
//                Assert.NotEmpty(receivedEvents);
//            }
//        }

//        #endregion

//        #region GetFilteredFilesTree

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilteredFilesTree_OneEventInvoked_StartedEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                      .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.StartedEvent += delegate (object sender, string e)
//                {
//                    receivedEvents.Add(e);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilteredFilesTree, path, filter);

//                Assert.Single(receivedEvents);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilteredFilesTree_OneEventInvoked_FinishedEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.FinishedEvent += delegate (object sender, string e)
//                {
//                    receivedEvents.Add(e);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilteredFilesTree, path, filter);

//                Assert.Single(receivedEvents);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilteredFilesTree_NoEventsInvoked_FileFoundEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.FilteredFileFoundEvent += delegate (object sender, TreeNode e)
//                {
//                    receivedEvents.Add(e.FileName);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilteredFilesTree, path, filter);

//                Assert.Empty(receivedEvents);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilteredFilesTree_SomeEventsInvoked_FileFoundEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                mock.Mock<IFileProvider>().Setup(x => x.GetFiles(path, filter.FileSearchPattern))
//                         .Returns(new string[] { "file1.txt", "file2.txt", "file3.txt" });

//                mock.Mock<IFileProvider>().Setup(x => x.GetFiles(path))
//                        .Returns(new string[] { "file1.txt", "file2.txt", "file3.txt" });

//                var cls = mock.Create<FileSystemService>();

//                cls.FilteredFileFoundEvent += delegate (object sender, TreeNode e)
//                {
//                    receivedEvents.Add(e.FileName);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilteredFilesTree, path, filter);

//                Assert.Equal(3, receivedEvents.Count);
//            }
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void GetFilteredFilesTree_OneEventInvoked_DirectoryFoundEvent(string path, Filter filter)
//        {
//            var receivedEvents = new List<string>();

//            using (var mock = AutoMock.GetLoose())
//            {
//                mock.Mock<IFileProvider>().Setup(x => x.DirectoryExist(path))
//                         .Returns(true);

//                var cls = mock.Create<FileSystemService>();

//                cls.FilteredDirectoryFoundEvent += delegate (object sender, string e)
//                {
//                    receivedEvents.Add(e);
//                };

//                var visitor = new FileSystemVisitor(cls.GetFilteredFilesTree, path, filter);
//                Assert.NotEmpty(receivedEvents);
//            }
//        }

//        #endregion
//    }
//}
