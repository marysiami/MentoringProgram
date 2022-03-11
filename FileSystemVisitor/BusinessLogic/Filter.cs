using System.IO;

namespace BusinessLogic
{
    public class Filter
    {
        public string DirSearchPattern { get; set; } = string.Empty;
        public bool FilteredDirStop { get; set; } = false;
        public bool FilteredDirEx { get; set; } = false;
        public string FileSearchPattern { get; set; } = string.Empty;
        public bool FilteredFileStop { get; set; } = false;
        public bool FilteredFileEx { get; set; } = false;

        public Filter() { }

        public Filter(string dirSearchPattern,
            string fileSearchPattern,
            bool filteredDirStop, 
            bool filteredDirEx, 
            bool filteredFileStop,
            bool filteredFileEx)
        {
            DirSearchPattern = dirSearchPattern;
            FileSearchPattern = fileSearchPattern;
            FilteredDirStop = filteredDirStop;
            FilteredDirEx = filteredDirEx; 
            FilteredFileStop = filteredFileStop;
            FilteredFileEx = filteredFileEx;
        }
    }    
}
