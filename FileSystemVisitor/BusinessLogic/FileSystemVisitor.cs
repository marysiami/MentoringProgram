using System;

namespace BusinessLogic.FileSystemVisitor
{
    public class FileSystemVisitor
    {
        public FileSystemVisitor(Action<string,Filter> getTreeAction, string path, Filter filter)
        {            
            getTreeAction(path, filter);
        }        
    }
}
