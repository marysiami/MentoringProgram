using System;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogic.FileSystemVisitor
{
    public class FileSystemService : IFileSystemService
    {
        public event EventHandler<string> StartedEvent;
        public event EventHandler<string> FinishedEvent;
        public event EventHandler<TreeNode> FileFoundEvent;
        public event EventHandler<TreeNode> FilteredFileFoundEvent;
        public event EventHandler<string> DirectoryFoundEvent;
        public event EventHandler<string> FilteredDirectoryFoundEvent;

        public void GetFilteredFilesTree(string path, Filter filter)
        {
            StartedEvent?.Invoke(this, path);

            if (string.IsNullOrEmpty(path))
                return;

            Stack<string> dirs = new Stack<string>(30);

            if (!Directory.Exists(path))
            {
                throw new ArgumentException();
            }
            dirs.Push(path);

            int i = 0;

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
        }

        public void GetFilesTree(string path, Filter filter)
        {
            StartedEvent?.Invoke(this, path);

            if (string.IsNullOrEmpty(path))
                return;

            Stack<string> dirs = new Stack<string>(30);

            if (!Directory.Exists(path))
            {
                throw new ArgumentException();
            }
            dirs.Push(path);

            int i = 0;

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
        }

        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchPattern))
                {
                    return Directory.GetDirectories(path, searchPattern,searchOption);                   
                }
                else
                {
                    return Directory.GetDirectories(path);
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
                    return Directory.GetFiles(path, searchPattern);                    
                }
                else
                {
                    return Directory.GetFiles(path);
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
