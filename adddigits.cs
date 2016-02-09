public class Solution {
    public int AddDigits(int num) {
        if (num == 0) return 0;
        var result = num % 9;
        return result == 0 ? 9 : result;
    }
}