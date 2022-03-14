using System.IO;
namespace BusinessLogic
{
    public class PhysicalFileProvider: IFileProvider
    {
        public bool DirectoryExist(string path)
        {
            return Directory.Exists(path);
        }
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
