/* Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned). */

public class Solution {
    public int Reverse(int x) {
       int rev = 0;
        while (x != 0) {
            int digit = x % 10;
            x /= 10;
            if (rev > int.MaxValue/10 ) return 0;
            if (rev < int.MinValue/10 ) return 0;
            rev = rev * 10 + digit;
        }
        return rev;
    }
}