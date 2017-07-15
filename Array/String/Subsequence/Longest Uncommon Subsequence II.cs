﻿/*
522. Longest Uncommon Subsequence II
Given a list of strings, you need to find the longest uncommon subsequence among them. The longest uncommon subsequence is defined as the longest subsequence of one of these strings and this subsequence should not be any subsequence of the other strings.

A subsequence is a sequence that can be derived from one sequence by deleting some characters without changing the order of the remaining elements. Trivially, any string is a subsequence of itself and an empty string is a subsequence of any string.

The input will be a list of strings, and the output needs to be the length of the longest uncommon subsequence. If the longest uncommon subsequence doesn't exist, return -1.

Example 1:
Input: "aba", "cdc", "eae"
Output: 3
Note:

All the given strings' lengths will not exceed 10.
The length of the given list will be in the range of [2, 50].
*/
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int FindLUSlength(string[] strs)
        {
            foreach (var s1 in strs.OrderByDescending(s=>s.Length))
            {
                int count = 0;
                foreach(var s2 in strs)
                {
                    if (IsSubsequence(s1, s2))
                    {
                        count++;
                    }
                }

                if (count == 1)
                {
                    return s1.Length;
                }
            }
            return -1;
        }
    }
}
