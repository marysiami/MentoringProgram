using System.Collections.Generic;

namespace BusinessLogic
{
    public class FileSystemVisitor
    {
        public delegate Filter GetFilter();
        private readonly IFileSystemService _fileSystemService;

        private TreeNode DirTree { get; set; }

        public FileSystemVisitor(IFileSystemService fileSystemService, string path, GetFilter getFilter)
        {
            _fileSystemService = fileSystemService;

            DirTree = _fileSystemService.GetTree(path, getFilter());
        }

        public TreeNode GetDirectoryTree()
        {
            return DirTree;
        }

    }
}
