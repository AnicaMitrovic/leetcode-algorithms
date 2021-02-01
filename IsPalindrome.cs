public class Solution {
    public bool IsPalindrome(int x) {
        // negative number is not a palindrome
        // if the last digit of the number is 0, the first digit of the number also needs to be 0.
        if(x < 0 || (x % 10 == 0 && x != 0))
            return false;
        
        var digits = new List<int>();

        for(int i = x; i != 0; i /= 10)
            digits.Add(i % 10);

        var arr = digits.ToArray();
        var reversedArr = new List<int>(arr).ToArray();
        Array.Reverse(reversedArr);

        return arr.SequenceEqual(reversedArr);
    }
}