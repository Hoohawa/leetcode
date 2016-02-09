/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        return root == null
              ? 0
              : Math.Max(
                  MaxDepth(root.left) + 1,
                  MaxDepth(root.right) + 1);
    }
}