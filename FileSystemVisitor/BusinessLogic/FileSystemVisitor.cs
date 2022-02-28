using System;

namespace BusinessLogic
{
    public class FileSystemVisitor
    {
        public int LastNodeIndex { get; } = 0;
        public FileSystemVisitor(Func<string,Filter,int> getTreeAction, string path, Filter filter)
        {
            LastNodeIndex = getTreeAction(path, filter);
        }        

    }
}
