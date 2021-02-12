/* You are given an array of N integers. You want to split them into N/2 pairs in such a way that the sum of integers in each pair is odd.
N is even and every element of array must be present in exactly one pair.
Task is to determine weather it is possible to split the numbers inte such pairs. For exemple, given [2,7,4,6,3,1]
the answer is true. --> (2,7), (6,3) and (4,1). Their sums are odd and the function returns true.
*/
using System;

class Solution {
    public int solution(int[] A) {
        int n = A.Length;
        if(n == 0){
            return false;
        }

        // Check if there are even elements in array
        if(n % 2 != 0){
            return false;
        }

        int countEven = 0;
        int countOdd = 0;
        // Loop through array and count even and odd numbers 
        for(int i = 0; i < n; i++){
            if(A[i] % 2 == 0){
                countEven++;
            }
            else{
                countOdd++;
            }
        }

        if(countEven == countOdd){
            return true;
        }
        else{
            return false;
        }
    }
}