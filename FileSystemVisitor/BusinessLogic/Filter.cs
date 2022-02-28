using System.IO;

namespace BusinessLogic
{
    public class Filter
    {
        public string DirSearchPattern { get; set; } = string.Empty;
        public SearchOption DirSearchOption { get; set; }
        public string FileSearchPattern { get; set; } = string.Empty;
        public int LastNodeIndex { get; set; }

        public Filter(int lastNodeIndex)
        {
            LastNodeIndex = lastNodeIndex; 
        }

        public Filter(int lastNodeIndex, string dirSearchPattern, SearchOption dirSearchOption, string fileSearchPattern)
        {
            LastNodeIndex = lastNodeIndex;
            DirSearchPattern = dirSearchPattern;
            DirSearchOption = dirSearchOption;
            FileSearchPattern = fileSearchPattern;
        }
    }    
}
