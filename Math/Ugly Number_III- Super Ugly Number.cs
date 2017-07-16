﻿/*
313	Super Ugly Number
easy, math, dp
Write a program to find the nth super ugly number.

Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k. For example, [1, 2, 4, 7, 8, 13, 14, 16, 19, 26, 28, 32] is the sequence of the first 12 super ugly numbers given primes = [2, 7, 13, 19] of size 4.

Note:
(1) 1 is a super ugly number for any given primes.
(2) The given numbers in primes are in ascending order.
(3) 0 < k ≤ 100, 0 < n ≤ 106, 0 < primes[i] < 1000.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_NthSuperUglyNumber()
        {
            NthSuperUglyNumber(12, new[] {2, 7, 13, 19});
        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            var dp = new int[n];
            dp[0] = 1;
            int[] index = new int[primes.Length];
            for (int i = 1; i < n; i++)
            {
                dp[i] = int.MaxValue;

                //this part can use priority queue
                for (int j = 0; j < primes.Length; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[index[j]]*primes[j]);
                }

                for (int j = 0; j < primes.Length; j++)
                {
                    if (dp[i] == dp[index[j]]*primes[j])
                    {
                        index[j]++;
                    }
                }
            }
            return dp[n - 1];
        }
    }
}
