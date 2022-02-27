using System;

namespace BusinessLogic.FileSystemVisitor
{
    public interface IFileSystemService
    {
        public event EventHandler<string> StartedEvent;
        public event EventHandler<string> FinishedEvent;
        public event EventHandler<TreeNode> FileFoundEvent;
        public event EventHandler<TreeNode> FilteredFileFoundEvent;
        public event EventHandler<string> DirectoryFoundEvent;
        public event EventHandler<string> FilteredDirectoryFoundEvent;

        public int GetFilteredFilesTree(string path, Filter filter);
        public int GetFilesTree(string path, Filter filter);
    }
}
