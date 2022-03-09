using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogic
{
    public class FileSystemService : IFileSystemService
    {
        public event EventHandler<string> StartedEvent;
        public event EventHandler<string> FinishedEvent;
        public event EventHandler<string> FileFoundEvent;
        public event EventHandler<string> FilteredFileFoundEvent;
        public event EventHandler<string> DirectoryFoundEvent;
        public event EventHandler<string> FilteredDirectoryFoundEvent;

        private readonly IFileProvider _fileProvider;
        public FileSystemService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public FileSystemService() { }
        public List<DirectoryNode> GetTree(string path, Filter filter)
        {
            StartedEvent?.Invoke(this, path);

            var dirs = new Stack<DirectoryNode>();
            var result = new List<DirectoryNode>();
            var temp = new List<DirectoryNode>();

            int i = 0;
            int fileIndex = 0;
            int dirIndex = 0;

            if (!_fileProvider.DirectoryExist(path))
            {
                throw new ArgumentException();
            }

            var mainDir = new DirectoryNode { 
                Path = path, 
                DirectoryID = dirIndex
            };

            dirs.Push(mainDir);

            while (dirs.Count > 0)
            {
                var currentDir = dirs.Pop();

                var dirNode = new DirectoryNode
                {
                    DirectoryID = dirIndex,
                    Path = currentDir.Path,
                    ParentID = currentDir.ParentID,
                };

                
                FilteredDirectoryFoundEvent?.Invoke(this, currentDir.Path);

                string[] subDirs = GetDirectories(currentDir.Path, filter.DirSearchPattern, filter.DirSearchOption);

                string[] files = GetFiles(currentDir.Path, filter.FileSearchPattern);

             
                foreach (var file in GetFilesInfo(files))
                {
                    dirNode.Files.Add(file.Name);
                    FilteredFileFoundEvent?.Invoke(this, file.Name);
                    fileIndex++;
                }

                foreach (string str in subDirs)
                {
                    var child = new DirectoryNode { Path = str, ParentID = currentDir.DirectoryID };
                    dirs.Push(child);
                }

                temp.Add(dirNode);

                i++;
                dirIndex++;
            }

            var parentsIDs = temp.Select(temp => temp.ParentID);

            foreach(var id in parentsIDs)
            {
                var parent = temp.Find(x => x.DirectoryID == id);

                if (id != null)
                {
                    var subDir = temp.Where(x => x.ParentID == id);
             
                    parent.Children.AddRange(subDir);
                }                  

                result.Add(parent);
            }

            FinishedEvent?.Invoke(this, path);

            return result;

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
