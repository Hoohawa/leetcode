public class Solution
{
    public int FindNextNonZero(int[] nums, int pos)
    {
        while (pos < nums.Length && nums[pos] == 0)
        {
            pos++;
        }
        return pos;
    }

    public void MoveZeroes(int[] nums)
    {
        var pos = FindNextNonZero(nums, 0);

        while (pos < nums.Length)
        {
            var nextNonNegative = FindNextNonZero(nums, pos);

            if (pos < nums.Length && nextNonNegative < nums.Length)
            {
                nums[pos] = nums[nextNonNegative];
                nums[nextNonNegative] = 0;
            }

            pos++;
        }
    }
}