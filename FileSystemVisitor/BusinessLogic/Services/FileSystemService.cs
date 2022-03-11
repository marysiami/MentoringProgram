using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
       
        public TreeNode GetTree(string path, Filter filter)
        {
            StartedEvent?.Invoke(this, path);

            var directoriesStack = new Stack<TreeNode>();

            if (!_fileProvider.DirectoryExist(path))
            {
                throw new ArgumentException();
            }

            var mainDir = new TreeNode { 
                Path = path, 
            };

            directoriesStack.Push(mainDir);

            while (directoriesStack.Count > 0)
            {
                var currentDir = directoriesStack.Pop();

                List<string> subDirs, files;

                subDirs = GetDirectories(currentDir.Path,filter);
                files = GetFiles(currentDir.Path, filter);
                           
                foreach (var file in GetFilesInfo(files))
                {
                    currentDir.Nodes.Add(new TreeNode { Path = file.Name });
                }

                foreach (string str in subDirs)
                {
                    var child = new TreeNode { Path = str };
                    currentDir.Nodes.Add(child);
                    directoriesStack.Push(child);
                }
            }

            FinishedEvent?.Invoke(this, path);

            return mainDir;

        }

        public List<string> GetDirectories(string path, Filter filter)
        {
            var result = new List<string>();
            try
            {
                var allDir = _fileProvider.GetDirectories(path).ToList();
                foreach (var dir in allDir)
                {
                    DirectoryFoundEvent?.Invoke(this, dir);
                }


                if (filter == null || string.IsNullOrEmpty(filter?.DirSearchPattern))
                {
                    result = allDir;
                }
                else 
                { 
                    Regex rx = new Regex(filter.DirSearchPattern);

                    foreach (var dir in allDir)
                    {
                        if (rx.IsMatch(dir))
                        {
                            FilteredDirectoryFoundEvent?.Invoke(this, dir);

                            if (filter.FilteredDirStop)
                            {
                                return result;
                            }

                            if (filter.FilteredDirStop)
                            {
                                continue;
                            }

                            result.Add(dir);                                                       
                        }
                    }                                   
                }                              
            }
            catch (UnauthorizedAccessException e)
            {// log to file
                //Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {// log to file
                //Console.WriteLine(e.Message);
            }

            return result;
        }

        public List<string> GetFiles(string path, Filter filter)
        {
            var result = new List<string>();
            try
            {
                var allFiles= _fileProvider.GetFiles(path).ToList();
                foreach (var file in allFiles)
                {                    
                    FileFoundEvent?.Invoke(this, file);
                }

                if (filter == null || string.IsNullOrEmpty(filter?.FileSearchPattern))
                {
                    result = allFiles;
                }
                else
                {
                    Regex rx = new Regex(filter.FileSearchPattern);

                    foreach (var file in allFiles)
                    {
                        var fileName = Path.GetFileName(file);

                        if (rx.IsMatch(fileName))
                        {
                            FilteredFileFoundEvent?.Invoke(this, file);

                            if (filter.FilteredFileStop)
                            {
                                return result;
                            }

                            if(filter.FilteredFileEx)
                            {
                                continue;
                            }
                           
                            result.Add(file);    
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                // log to file
                //Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                // log to file
                //Console.WriteLine(e.Message);
            }

            return result;
        }

        public IEnumerable<FileInfo> GetFilesInfo(List<string> files)
        {
            if (files != null && files.Count > 0)
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
