using System.Linq;

namespace WindowsFormsApp
{
    public static class TreeNodeHelper
    {
        public static System.Windows.Forms.TreeNode ToWindowsFormsTreeNode(this BusinessLogic.TreeNode node)
        {
            var resultNode = new System.Windows.Forms.TreeNode
            {
                Text = node.Path,
            };
                
            if (node.Nodes != null && node.Nodes.Any())
            {
                resultNode.Nodes.AddRange(node.Nodes.Select(x => x.ToWindowsFormsTreeNode()).ToArray());
            }

            return resultNode;
        }
    }
}
