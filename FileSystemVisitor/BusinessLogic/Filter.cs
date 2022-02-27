using System.IO;

namespace BusinessLogic.FileSystemVisitor
{
    public class Filter
    {
        public string DirSearchPattern { get; set; } = string.Empty;
        public SearchOption DirSearchOption { get; set; }
        public string FileSearchPattern { get; set; } = string.Empty;

        public int LastNodeIndex { get; set; }

    }    
}
