/*
An array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, and the last element of the array is moved to the first place. For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] (elements are shifted right by one index and 6 is moved to the first place).

The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.
*/

using System;
class Solution {
    public int[] solution(int[] A, int K) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if (A.Length == 0)
        {
            return A;
        }

        int change = 0;

        for (int j = 0; j< K; j++)
        {
            change = A[A.Length - 1];
            for (int i = A.Length - 1; i > 0; i--)
                A[i] = A[i - 1];
            A[0] = change;
        }

        return A;
    }
}