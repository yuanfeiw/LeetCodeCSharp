﻿/*
77	Combinations
easy, recursive
Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

For example,
If n = 4 and k = 2, a solution is:

[
  [2,4],
  [3,4],
  [2,3],
  [1,2],
  [1,3],
  [1,4],
]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var ret = new List<IList<int>>();
            Combine(ret, new List<int>(), 1, n, k);
            return ret;
        }

        public void Combine(IList<IList<int>> ret, List<int> current, int c, int n, int k)
        {
            // happy
            if (k == 0)
            {
                ret.Add(new List<int>(current));
                return;
            }

            // unhappy
            if (n - c + 1 < k)
            {
                return;
            }

            // choose
            current.Add(c);
            Combine(ret, current, c + 1, n, k - 1);
            current.Remove(c);

            // not choose
            Combine(ret, current, c + 1, n, k);
        }
    }
}
