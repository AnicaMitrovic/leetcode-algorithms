/*
Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).

The algorithm for myAtoi(string s) is as follows:

    Read in and ignore any leading whitespace.
    Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
    Read in next the characters until the next non-digit charcter or the end of the input is reached. The rest of the string is ignored.
    Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
    If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
    Return the integer as the final result.
*/
public class Solution {
    public int MyAtoi(string s) {
// Discard all the whitespaces at the beginning of the string.
            s = s.Trim();
            

            if (s.Length == 0)
                return 0;
            Int32 ret = 0;

// Check if the next character (if not already at the end of the string) is '-' or '+'
            bool isnegative = s.Substring(0, 1) == "-";
            bool ispositive = s.Substring(0, 1) == "+";
            
            for (int i = isnegative || ispositive?1: 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    if (ret > int.MaxValue / 10 
                        || (ret == int.MaxValue / 10 && Int32.Parse(s[i].ToString()) -0 > Int32.MaxValue % 10))
                    {
                        return isnegative ? Int32.MinValue : (Int32.MaxValue);
                    }
                    ret = ret * 10 + Int32.Parse(s[i].ToString());
                }
                else
                    break;
            }
            return isnegative?ret*-1:ret;
    }
}