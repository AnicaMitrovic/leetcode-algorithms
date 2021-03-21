/*
Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
Return the quotient after dividing dividend by divisor.
The integer division should truncate toward zero, which means losing its fractional part. For example, truncate(8.345) = 8 and truncate(-2.7335) = -2.

Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. 
For this problem, assume that your function returns 231 − 1 when the division result overflows.
*/
public class Solution {
    public int Divide(int dividend, int divisor) {
        if (divisor == 1) { return dividend; }
        if (divisor == -1 &&  dividend == int.MinValue) { return int.MaxValue; }
        if (dividend == divisor) { return 1; }
        if (dividend == 0 || divisor == int.MinValue) { return 0; }
        
        bool isNeg = (dividend < 0 && divisor > 0) ||  (dividend > 0 && divisor < 0);
        
        int count = 0;
        if (dividend == int.MinValue)
        {
            if (divisor < 0) {  dividend -= divisor; } else { dividend += divisor; }
            count++;
        }
        
        int dvd = (dividend < 0)? -dividend: dividend;
        int dvs = (divisor < 0)? -divisor: divisor;
         
        int temp = dvs;
        int i = 0;
        while(temp > 0)
        {
           i++;
           temp>>=1;
        }   
        
        int multi=31-i;
        
        while (dvd >= dvs)
        {   
            temp = dvs;
            while((temp << multi) > dvd) { multi--; }
                 
            dvd -= temp << multi;
            count += 1 << multi; 
        }  
                  
        if (isNeg) { count = -count; }
        
        return count;
    }
}
