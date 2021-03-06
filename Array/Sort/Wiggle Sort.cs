﻿/*
280	Wiggle Sort $
easy, math
Given an unsorted array nums, reorder it in-place such that nums[0] <= nums[1] >= nums[2] <= nums[3]....

For example, given nums = [3, 5, 2, 1, 6, 4], one possible answer is [1, 6, 2, 5, 3, 4].
*/

namespace Demo
{
    public partial class Solution
    {
        public void WiggleSort2(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                // i is odd, nums[i] >= nums[i - 1]
                // is is even，nums[i] <= nums[i - 1]
                if ((i%2 == 1 && nums[i] < nums[i - 1]) || (i%2 == 0 && nums[i] > nums[i - 1]))
                {
                    int tmp = nums[i - 1];
                    nums[i - 1] = nums[i];
                    nums[i] = tmp;
                }
            }
        }
    }
}