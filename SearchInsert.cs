/* Given a sorted array of distinct integers and a target value, return the index if the target is found. 
If not, return the index where it would be if it were inserted in order. */

public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int length = nums.Length;
				for (int i = 0; i < length; i++)
				{
					if (nums[i] == target)
					{
						return i;
					}

					if (nums[i] > target)
					{
						return i;
					}
				}

				return length;
    }
}