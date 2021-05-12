using Utils;

namespace _2020_01_05
{
   
    //Definition for a binary tree node.
    

    public class _202005:Singleton<_202005>
    {
        internal class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        //https://leetcode-cn.com/problems/subtree-of-another-tree/
        //给定两个非空二叉树 s 和 t，检验 s 中是否包含和 t 具有相同结构和节点值的子树。s 的一个子树包括 s 的一个节点和这个节点的所有子孙。s 也可以看做它自身的一棵子树。

        //public bool IsSubtree(TreeNode s, TreeNode t)
        //{

        //}
    }
}