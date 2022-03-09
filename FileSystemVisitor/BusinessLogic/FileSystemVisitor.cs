using System.Collections.Generic;

namespace BusinessLogic
{
    public class FileSystemVisitor
    {
        private readonly IFileSystemService _fileSystemService;

        public int LastNodeIndex { get; } = 0;
        public List<DirectoryNode> DirTree { get; set; }
                
        public FileSystemVisitor(IFileSystemService fileSystemService, string path, Filter filter)
        {
            _fileSystemService = fileSystemService;

            DirTree = _fileSystemService.GetTree(path,filter);
        }

    }
}
