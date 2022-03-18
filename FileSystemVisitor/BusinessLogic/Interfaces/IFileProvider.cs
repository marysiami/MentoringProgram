namespace BusinessLogic
{
    public interface IFileProvider
    {
        string[] GetFiles(string path);
        string[] GetDirectories(string path);
        bool DirectoryExist(string path);
        bool FileExists(string path);
    }
}
