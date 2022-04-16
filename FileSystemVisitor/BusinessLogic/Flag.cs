using System.IO;

namespace BusinessLogic
{
    public class Flag
    {
        public bool FilteredDirStop { get; set; } = false;
        public bool FilteredDirEx { get; set; } = false;
        public bool FilteredFileStop { get; set; } = false;
        public bool FilteredFileEx { get; set; } = false;

        public Flag() { }

        public Flag(
            bool filteredDirStop, 
            bool filteredDirEx, 
            bool filteredFileStop,
            bool filteredFileEx)
        {
            FilteredDirStop = filteredDirStop;
            FilteredDirEx = filteredDirEx; 
            FilteredFileStop = filteredFileStop;
            FilteredFileEx = filteredFileEx;
        }
    }    
}
