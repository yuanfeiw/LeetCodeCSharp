﻿/*
277	Find the Celebrity
easy
Problem Description:

Suppose you are at a party with n people (labeled from 0 to n - 1) and among them, there may exist one celebrity. The definition of a celebrity is that all the other n - 1 people know him/her but he/she does not know any of them.

Now you want to find out who the celebrity is or verify that there is not one. The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible (in the asymptotic sense).

You are given a helper function bool knows(a, b) which tells you whether A knows B. Implement a function int findCelebrity(n), your function should minimize the number of calls to knows.

Note: There will be exactly one celebrity if he/she is in the party. Return the celebrity's label if there is a celebrity in the party. If there is no celebrity, return -1.


*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        private bool Knows(int a, int b)
        {
            return false;
        }

        public int FindCelebrity(int n)
        {
            var candidates = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                candidates.Push(i);
            }

            while (candidates.Count >= 2)
            {
                int a = candidates.Pop();
                int b = candidates.Pop();
                candidates.Push(Knows(a, b) ? b : a);
            }

            int c = candidates.Pop();
            for (int i = 0; i < n; i++)
            {
                if (i == c)
                {
                    continue;
                }

                if (Knows(c, i) || !Knows(i, c))
                {
                    return -1;
                }
            }

            return c;
        }

        public int FindCelebrity2(int n)
        {
            int c = 0;
            for (int i = 1; i < n; i++)
            {
                if (Knows(c, i))
                {
                    c = i;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i == c)
                {
                    continue;
                }

                if (!Knows(i, c) || Knows(c, i))
                {
                    return -1;
                }
            }

            return c;
        }
    }
}
