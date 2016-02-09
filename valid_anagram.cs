public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        var count1 = new int[26];
        var count2 = new int[26];

        if (s.Length != t.Length)
        {
            return false;
        }

        for (var i = 0; i < s.Length; i++)
        {
            count1[s[i] - 'a']++;
            count2[t[i] - 'a']++;
        }

        for (var i = 0; i < 26; i++)
        {
            if (count1[i] != count2[i])
                return false;
        }

        return true;
    }
}