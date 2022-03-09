using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IFileSystemService
    {
        public event EventHandler<string> StartedEvent;
        public event EventHandler<string> FinishedEvent;
        public event EventHandler<string> FileFoundEvent;
        public event EventHandler<string> FilteredFileFoundEvent;
        public event EventHandler<string> DirectoryFoundEvent;
        public event EventHandler<string> FilteredDirectoryFoundEvent;

        List<DirectoryNode> GetTree(string path, Filter filter);
    }
}
