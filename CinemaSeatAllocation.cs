/* Return the maximum number of four-person groups you can assign on the cinema seats. 
A four-person group occupies four adjacent seats in one single row. Seats across an aisle (such as [3,C] and [3,D]) 
are not considered to be adjacent, but there is an exceptional case on which an aisle split a four-person group, 
in that case, the aisle split a four-person group in the middle, which means to have two people on each side. */
using System;
class Solution {
        public int solution(int N, string S)
        {
            string[] reservedSeatsString = S.Split(' '); 

            // Contains reserved seats in every row
            Dictionary<int, List<char>> reservedSeatsInRow = new Dictionary<int, List<char>>();

            foreach (var mark in reservedSeatsString)
            {
                if (mark != "")
                {
                    char[] arr = mark.ToCharArray();
                    int markNum = (int)Char.GetNumericValue(arr[0]); // 3
                    char markLetter = Convert.ToChar(arr[1]); // C

                    if (markLetter == 'A' || markLetter == 'K')
                    {
                        // If the seat is A or K , return 0, we don't need to take them into account
                        continue;
                    }

                    if (reservedSeatsInRow.ContainsKey(markNum))
                    {
                        reservedSeatsInRow[markNum].Add(markLetter);
                    }
                    else
                    {
                        reservedSeatsInRow.Add(markNum, new List<char>());
                        reservedSeatsInRow[markNum].Add(markLetter);
                    }
                }
                else
                {
                    // No reserved seats, in every row we can place two four-person families ()
                    return N * 2;
                }
            }

            int numberOfFamilies = 0;

            for (int i = 1; i <= N; i++)
            {
                if(!reservedSeatsInRow.ContainsKey(i)) // Row is empty, we can place two families
                {
                    numberOfFamilies += 2;
                }
                else
                {
                    var values = reservedSeatsInRow[i];

                    if (values.Count > 4)
                    {
                        // If 5 ore more seats (between B and J) are taken, there is no place for four-person family at all
                        continue;
                    }
                    else
                    {
                        if (values.Count == 1)
                        {
                            numberOfFamilies++;
                            continue;
                        }

                        char[] completeRow = { 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J' };

                        // Possible sitting combinations
                        char[] left = { 'B', 'C', 'D', 'E' };
                        char[] middle = { 'D', 'E', 'F', 'G' };
                        char[] right = { 'F', 'G', 'H', 'J' };

                        char[] freeSeatsInRow = completeRow.Except(values).ToArray();

                        if(left.All(x => freeSeatsInRow.Contains(x)))
                        {
                            numberOfFamilies++;
                            continue;
                        }

                        if (middle.All(x => freeSeatsInRow.Contains(x)))
                        {
                            numberOfFamilies++;
                            continue;
                        }

                        if (right.All(x => freeSeatsInRow.Contains(x)))
                        {
                            numberOfFamilies++;
                            continue;
                        }
                    }
                }
            }

            return numberOfFamilies;
        }
}