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