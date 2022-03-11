using System.Collections.Generic;

namespace BusinessLogic
{
    public class TreeNode
    {
        public int DirectoryID { get; set; }
        public string Path { get; set; }
        public int? ParentID { get; set; }
        public List<TreeNode> Nodes { get; set; }=  new List<TreeNode>();
    }
   
}
