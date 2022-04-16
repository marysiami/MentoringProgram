using System;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogic
{
    public class FileSystemVisitor
    {
        public event EventHandler<string> StartedEvent;
        public event EventHandler<string> FinishedEvent;
        public event EventHandler<string> FileFoundEvent;
        public event EventHandler<string> FilteredFileFoundEvent;
        public event EventHandler<string> DirectoryFoundEvent;
        public event EventHandler<string> FilteredDirectoryFoundEvent;

        public delegate bool DirFilter(string path);
        public delegate bool FileFilter(string path);
        
        private readonly IFileProvider _fileProvider;
        private DirFilter DirFilterMethod { get; set; }
        private FileFilter FileFilterMethod { get; set; }
        private Flag Flag { get; set; }

        public FileSystemVisitor(IFileProvider fileProvider, Flag flag = null, DirFilter dirFilter = null, FileFilter fileFilter = null)
        {
            DirFilterMethod = dirFilter;
            FileFilterMethod = fileFilter;
            _fileProvider = fileProvider;
            Flag = flag;
        }

        public IEnumerable<string> GetAllFilesAndDirs(string path)
        {
            StartedEvent?.Invoke(this, path);

            var result = new List<string>();
            var directoriesStack = new Stack<string>();

            if (!_fileProvider.DirectoryExist(path))
            {
                throw new ArgumentException();
            }

            directoriesStack.Push(path);

            while (directoriesStack.Count > 0)
            {
                var currentDir = directoriesStack.Pop();

                result.Add(currentDir);

                string[] subDirs, files;

                subDirs = _fileProvider.GetDirectories(currentDir);
                foreach (var dir in subDirs)
                {
                    DirectoryFoundEvent?.Invoke(this, dir);
                    directoriesStack.Push(dir);
                }

                files = _fileProvider.GetFiles(currentDir);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    FileFoundEvent?.Invoke(this, fileName);
                    result.Add(file);
                }
            }

            foreach (string el in result)
            {
                var fileName = Path.GetFileName(el);

                if (_fileProvider.DirectoryExist(el))
                {
                    if (DirFilterMethod != null)
                    {
                        if (DirFilterMethod(fileName))
                        {
                            FilteredDirectoryFoundEvent?.Invoke(this, el);

                            if (Flag == null || !Flag.FilteredDirEx)
                            {
                                yield return el;
                            }

                            if (Flag != null && Flag.FilteredDirStop)
                            {
                                yield break;
                            }
                        }
                    }
                    else
                    {
                        yield return el;
                    }   
                }
                else if (_fileProvider.FileExists(el))
                {
                    if (FileFilterMethod != null)
                    {
                        if (FileFilterMethod(fileName))
                        {
                            FilteredFileFoundEvent?.Invoke(this, fileName);

                            if (Flag == null || !Flag.FilteredFileEx)
                            {
                                yield return el;
                            }

                            if (Flag != null && Flag.FilteredFileStop)
                            {
                                yield break;
                            }          
                        }
                    }
                    else
                    {
                        yield return el;
                    }  
                }
            }            

            FinishedEvent?.Invoke(this, path);
        }      
    }
}
