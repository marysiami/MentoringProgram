using System.IO;

namespace BusinessLogic
{
    public interface IFileProvider
    {
        string[] GetFiles(string path, string searchPattern);
        string[] GetFiles(string path);
        string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        string[] GetDirectories(string path);
        bool DirectoryExist(string path);
    }
}
