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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {

        if (p == null && q == null)
        {
            return true;
        }
        else if (p == null || q == null)
        {
            return false;
        }
        else
        {
            var IsSameRoot = p.val == q.val;
            var IsSameTreeLeft = IsSameTree(p.left, q.left);
            var IsSameTreeRight = IsSameTree(p.right, q.right);

            return IsSameRoot
                && IsSameTreeLeft
                && IsSameTreeRight;
        }

    }
}