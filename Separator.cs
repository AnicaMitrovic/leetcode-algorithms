/*
Given an integer n, add a dot (".") as the thousands separator and return it in string format.
*/

public class Solution {
    public string ThousandSeparator(int n) {
         
        if(n < 1000) return n.ToString();
        var sb = new StringBuilder();
        var nstr = n.ToString();
        int counter = 0;
        for(int i = nstr.Length -1; i >= 0; i--)
        {
            counter++;
            sb.Insert(0, nstr[i]);
             if(counter == 3 && i >= 1)
             {
                sb.Insert(0, '.');    
                counter = 0;
             }
        }
        return sb.ToString();       
    }
}