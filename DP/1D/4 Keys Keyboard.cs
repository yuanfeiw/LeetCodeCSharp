﻿/*
651. 4 Keys Keyboard
Imagine you have a special keyboard with the following keys:

Key 1: (A): Prints one 'A' on screen.

Key 2: (Ctrl-A): Select the whole screen.

Key 3: (Ctrl-C): Copy selection to buffer.

Key 4: (Ctrl-V): Print buffer on screen appending it after what has already been printed.

Now, you can only press the keyboard for N times (with the above four keys), find out the maximum numbers of 'A' you can print on screen.

Example 1:
Input: N = 3
Output: 3
Explanation: 
We can at most get 3 A's on screen by pressing following key sequence:
A, A, A
Example 2:
Input: N = 7
Output: 9
Explanation: 
We can at most get 9 A's on screen by pressing following key sequence:
A, A, A, Ctrl A, Ctrl C, Ctrl V, Ctrl V
Note:
1 <= N <= 50
Answers will be in the range of 32-bit signed integer.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxA2(int N)
        {
            int res = N;
            for (int i = 1; i < N - 2; ++i)
            {
                res = Math.Max(res, MaxA(i) * (N - i - 1));
            }

            return res;
        }
        public int MaxA(int N)
        {
            int[] dp = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                // press A
                dp[i] = i;
                for (int j = 3; j < i; j++)
                {
                    // dp[i - j], press ctrl A, ctrl C, press j-2 ctrl V;
                    dp[i] = Math.Max(dp[i], dp[i - j] * (j - 1));
                }
            }

            return dp[N];
        }
    }
}
