﻿/*
441. Arranging Coins
You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.

Given n, find the total number of full staircase rows that can be formed.

n is a non-negative integer and fits within the range of a 32-bit signed integer.

Example 1:

n = 5

The coins can form the following rows:
¤
¤ ¤
¤ ¤

Because the 3rd row is incomplete, we return 2.
Example 2:

n = 8

The coins can form the following rows:
¤
¤ ¤
¤ ¤ ¤
¤ ¤

Because the 4th row is incomplete, we return 3.
*/

namespace Demo
{
    public partial class Solution
    {
        public int ArrangeCoins(int n)
        {
            // y=x(x+1)/2
            // find first x where cannot meet x(x+1)/2 <= n
            // 5
            // 1 3 6
            int low = 1;
            int high = n;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                if ( ((long)mid)*(mid + 1)/2<=n)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low -1;
        }
    }
}
