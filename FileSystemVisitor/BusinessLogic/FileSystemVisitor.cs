using System.Collections.Generic;

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
            return _fileSystemService.GetAll(path, DirFilterMethod, FileFilterMethod);          
        }
    }
}
