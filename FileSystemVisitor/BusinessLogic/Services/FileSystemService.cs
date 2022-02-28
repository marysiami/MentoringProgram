using System;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogic
{
    public class FileSystemService : IFileSystemService
    {
        public event EventHandler<string> StartedEvent;
        public event EventHandler<string> FinishedEvent;
        public event EventHandler<TreeNode> FileFoundEvent;
        public event EventHandler<TreeNode> FilteredFileFoundEvent;
        public event EventHandler<string> DirectoryFoundEvent;
        public event EventHandler<string> FilteredDirectoryFoundEvent;

        private readonly IFileProvider _fileProvider;
        public FileSystemService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public FileSystemService() { }

        public int GetFilteredFilesTree(string path, Filter filter)
        {
            StartedEvent?.Invoke(this, path);

            Stack<string> dirs = new Stack<string>();

            if (!_fileProvider.DirectoryExist(path))
            {
                throw new ArgumentException();
            }
            dirs.Push(path);

            int i = 0;
            if (filter != null)
            {
                i = filter.LastNodeIndex;
            }
            else
            {
                filter = new Filter(0);
            }

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();

                FilteredDirectoryFoundEvent?.Invoke(this, currentDir);

                string[] subDirs = GetDirectories(currentDir, filter.DirSearchPattern, filter.DirSearchOption);

                string[] files = GetFiles(currentDir, filter.FileSearchPattern);

                foreach (var file in GetFilesInfo(files))
                {
                    var node = new TreeNode
                    {
                        FileName = file.Name,
                        DirectoryId = i
                    };

                    FilteredFileFoundEvent?.Invoke(this, node);
                }

                foreach (string str in subDirs)
                    dirs.Push(str);

                i++;
            }

            FinishedEvent?.Invoke(this, path);

            return i;
        }

        public int GetFilesTree(string path, Filter filter)
        {
            StartedEvent?.Invoke(this, path);

            Stack<string> dirs = new Stack<string>();

            if (!_fileProvider.DirectoryExist(path))
            {
                throw new ArgumentException();
            }

            dirs.Push(path);

            int i = 0;
            if (filter != null)
            {
                i = filter.LastNodeIndex;
            }

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();

                DirectoryFoundEvent?.Invoke(this, currentDir);

                string[] subDirs = GetDirectories(currentDir, null, SearchOption.AllDirectories);

                string[] files = GetFiles(currentDir, null);

                foreach(var file in GetFilesInfo(files))
                {
                    var node = new TreeNode
                    {
                        FileName = file.Name,
                        DirectoryId = i
                    };

                    FileFoundEvent?.Invoke(this, node);
                }

                foreach (string str in subDirs)
                    dirs.Push(str);

                i++;
            }

            FinishedEvent?.Invoke(this, path);

            return i;
        }

        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchPattern))
                {
                    return _fileProvider.GetDirectories(path, searchPattern,searchOption);                   
                }
                else
                {
                    return _fileProvider.GetDirectories(path);
                }                              
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return new string[0];
        }

        public string[] GetFiles(string path, string searchPattern)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchPattern))
                {                    
                    return _fileProvider.GetFiles(path, searchPattern);                    
                }
                else
                {
                    return _fileProvider.GetFiles(path);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return new string[0];
        }

        public IEnumerable<FileInfo> GetFilesInfo(string[] files)
        {
            if (files != null && files.Length > 0)
            {
                foreach (string file in files)
                {
                    if (string.IsNullOrEmpty(file))
                        throw new FileNotFoundException();

                    FileInfo fi;
                    try
                    {
                        fi = new FileInfo(file);
                    }
                    catch (FileNotFoundException e)
                    {
                        throw new FileNotFoundException(e.Message);
                    }

                    yield return fi;
                }
            }            
        }
    }
}
