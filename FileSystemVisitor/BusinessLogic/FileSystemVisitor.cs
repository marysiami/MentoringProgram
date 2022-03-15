using System.Collections.Generic;
using System.IO;

namespace BusinessLogic
{
    public class FileSystemVisitor
    {
        public delegate bool DirFilter(string path);
        public delegate bool FileFilter(string path);

        private readonly IFileSystemService _fileSystemService;             
        private DirFilter DirFilterMethod { get; set; }
        private FileFilter FileFilterMethod { get; set; }

        public FileSystemVisitor(IFileSystemService fileSystemService, DirFilter dirFilter, FileFilter fileFilter)
        {
            _fileSystemService = fileSystemService;
            DirFilterMethod = dirFilter;
            FileFilterMethod = fileFilter;
        }

        public IEnumerable<string> GetAll(string path)
        {
            return _fileSystemService.GetAll(path);          
        }
        public IEnumerable<string> GetFilteredList(IEnumerable<string> list)
        {
            foreach (string el in list)
            {
                if (Directory.Exists(el))
                {
                    if (DirFilterMethod(el))
                    {
                        //FilteredDirectoryFoundEvent?.Invoke(this, dir);
                       yield return el;
                    }

                }
                else if (File.Exists(el))
                {
                    var fileName = Path.GetFileName(el);
                    if (FileFilterMethod(fileName))
                    {
                        //FilteredFileFoundEvent?.Invoke(this, file);
                        yield return fileName;
                    }
                }
            }
           


        }
    }
}
