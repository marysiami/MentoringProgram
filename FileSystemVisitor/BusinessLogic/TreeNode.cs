using System.Collections.Generic;

namespace BusinessLogic
{
    public class DirectoryNode
    {
        public int DirectoryID { get; set; }
        public string Path { get; set; }
        public int? ParentID { get; set; }
        public List<string> Files { get; set; } = new List<string>();
        public List<DirectoryNode> Children { get; set; }=  new List<DirectoryNode>();
    }
   
}
