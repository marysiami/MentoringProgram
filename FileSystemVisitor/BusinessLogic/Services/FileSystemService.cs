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

        private const string LogFilePath = "ERROR_LOGS.txt";
        private TextWriter LogWriter;

        private readonly IFileProvider _fileProvider;

        public FileSystemService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            LogWriter = new StreamWriter(LogFilePath, true);
        }
        public IEnumerable<string> GetAll(string path, FileSystemVisitor.DirFilter dirFilterMethod, FileSystemVisitor.FileFilter fileFilterMethod)
        {
            StartedEvent?.Invoke(this, path);
            var result = new List<string>();
            var directoriesStack = new Stack<string>();

            if (!_fileProvider.DirectoryExist(path))
            {
                LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} ArgumentException: {path}");
                throw new ArgumentException();
            }

            directoriesStack.Push(path);

            while (directoriesStack.Count > 0)
            {
                var currentDir = directoriesStack.Pop();

                result.Add(currentDir);

                List<string> subDirs, files;

                subDirs = GetDirectories(currentDir, dirFilterMethod);
                files = GetFiles(currentDir, fileFilterMethod);

                foreach (var file in GetFilesInfo(files))
                {
                    result.Add(file.Name);
                }

                foreach (string str in subDirs)
                {
                    directoriesStack.Push(str);
                }
            }

            FinishedEvent?.Invoke(this, path);

            LogWriter.Close();

            return result;
        }

        public List<string> GetDirectories(string path, FileSystemVisitor.DirFilter dirFilterMethod)
        {
            var result = new List<string>();
            try
            {
                var allDir = _fileProvider.GetDirectories(path).ToList();
                foreach (var dir in allDir)
                {
                    DirectoryFoundEvent?.Invoke(this, dir);

                    if (dirFilterMethod(dir))
                    {
                        FilteredDirectoryFoundEvent?.Invoke(this, dir);
                        result.Add(dir);
                    }
                }                  
            }
            catch (UnauthorizedAccessException e)
            {
                LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} UnauthorizedAccessException: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} DirectoryNotFoundException: {e.Message}");
            }

            return result;
        }

        public List<string> GetFiles(string path, FileSystemVisitor.FileFilter fileFilterMethod)
        {
            var result = new List<string>();
            try
            {
                var allFiles= _fileProvider.GetFiles(path).ToList();
                foreach (var file in allFiles)
                {                    
                    FileFoundEvent?.Invoke(this, file);

                    var fileName = Path.GetFileName(file);
                    if (fileFilterMethod(fileName))
                    {
                        FilteredFileFoundEvent?.Invoke(this, file);                        
                        result.Add(file);
                    }               
                }
            }
            catch (UnauthorizedAccessException e)
            {
               LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} UnauthorizedAccessException: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
               LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} DirectoryNotFoundException: {e.Message}");
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
                    {
                        LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} FileNotFoundException: file name is null or empty");
                        throw new FileNotFoundException();
                    }                        

                    FileInfo fi;
                    try
                    {
                        fi = new FileInfo(file);
                    }
                    catch (FileNotFoundException e)
                    {
                        LogWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} FileNotFoundException: {e.Message}");   
                        throw new FileNotFoundException(e.Message);
                    }

                    yield return fi;
                }
            }            
        }
    }
}
