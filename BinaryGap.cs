/*
A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.
For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. The number 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation 100000 and has no binary gaps.

Write a function:

    class Solution { public int solution(int N); }

that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.
For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5. Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.
Write an efficient algorithm for the following assumptions:
N is an integer within the range [1..2,147,483,647]
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