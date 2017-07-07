﻿/*
62	Unique Paths
Unique Paths

A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?


Above is a 3 x 7 grid. How many possible unique paths are there?

Note: m and n will be at most 100.
*/

namespace Demo
{
    public partial class Solution
    {
        public int UniquePaths(int m, int n)
        {
            return m > n ? Choose(m + n - 2, n - 1) : Choose(m + n - 2, m - 1);
        }

        public int Choose(int total, int choose)
        {
            int[,] dp = new int[total + 1, choose + 1];
            for (int i = 0; i <= total; i++)
            {
                for (int j = 0; j <= choose; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return Choose(total, choose, dp);
        }

        public int Choose(int total, int choose, int[,] dp)
        {
            if (dp[total, choose] != -1)
            {
                return dp[total, choose];
            }

            int ret;
            if (total < choose)
            {
                ret = 0;
            }
            else if (choose == 0 || choose == total)
            {
                ret = 1;
            }
            else
            {
                ret = Choose(total - 1, choose - 1, dp)
                      + Choose(total - 1, choose, dp);
            }
            dp[total, choose] = ret;
            return ret;
        }

        public int UniquePaths2(int m, int n)
        {
            return m > n ? Choose2(m + n - 2, n - 1) : Choose2(m + n - 2, m - 1);
        }

        public int Choose2(int total, int choose)
        {
            // nck= (n-1)c(k-1) *n/k
            long nCk = 1;
            for (int i = 1; i <= choose; i++)
            {
                nCk = nCk*(total - choose + i)/i;
            }
            return (int) nCk;
        }

        // prefer
        public int UniquePaths4(int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];
            dp[m - 1, n] = 1;

            for (int r = m-1; r >= 0; r--)
            {
                for (int c = n-1; c >= 0; c--)
                {
                    dp[r, c] = dp[r + 1, c] + dp[r, c + 1];
                }
            }
            return dp[0, 0];
        }
    }
}
