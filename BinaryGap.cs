/*

*/
using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    public int solution(int N) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
                    if (N >= 0 && N < 5)
            {
                return 0;
            }

            var binary = Convert.ToString(N, 2);
            Dictionary<int, int> found = new Dictionary<int, int>(); // Dictionary<gap number(1st, 2nd..), length of that gap>
            int gap = 1; // store number of gaps we have
            int j = 0;

            // We skip first element since it's always 1, and we begin from binary[1]
            for (int i = 1; i < binary.Length; i++)
            {                
                if (binary[i] == '0')
                {
                    if (i == binary.Length - 1 && binary[i] == '0') // we came to the end and the last number is 0, we remove the last counting
                    {
                        found.Remove(gap);
                        gap--;
                        continue;
                    }
                    // record the fact that we found 0
                    if (found.ContainsKey(gap))
                    {
                        found[gap] = ++j;
                    }
                    else
                    {
                        found.Add(gap, ++j);
                    }                  
                    continue;
                }
                else if (binary[i] == '1' && j > 0) // we found a gap
                {
                    gap++;
                    j = 0;
                    continue;
                }
            }

            return found.Count != 0 ? found.Values.Max() : 0;
    }
}