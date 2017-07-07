﻿/*
300	Longest Increasing Subsequence
easy, dp, o(nlogn)
Given an unsorted array of integers, find the length of longest increasing subsequence.

For example,
Given [10, 9, 2, 5, 3, 7, 101, 18],
The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4. Note that there may be more than one LIS combination, it is only necessary for you to return the length.

Your algorithm should run in O(n2) complexity.

Follow up: Could you improve it to O(n log n) time complexity?
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        // http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/
        public int LongestIncreasingSubsequenceLength(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int res = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        res = Math.Max(dp[i], res);
                    }
                }
            }
            return res;
        }
    }
}