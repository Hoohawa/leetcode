public class Solution
{
    public string ShortestPalindrome(string s)
    {
        var sb = new StringBuilder();

        var left = 0;
        var right = s.Length - 1;
        var postFixPos = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                sb.Append(s[postFixPos--]);
                left = 0;
                right = postFixPos + 1;
            }
            else
            {
                left++;
            }
            right--;
        }

        return sb.Append(s).ToString();
    }
}