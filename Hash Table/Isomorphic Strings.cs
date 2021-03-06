﻿/*
205	Isomorphic Strings
easy, *
Isomorphic Strings

Given two strings s and t, determine if they are isomorphic.

Two strings are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.

For example,
Given "egg", "add", return true.

Given "foo", "bar", return false.

Given "paper", "title", return true.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            var m1 = new int[256];
            var m2 = new int[256];
            int n = s.Length;
            for (int i = 0; i < n; ++i)
            {
                if (m1[s[i]] != m2[t[i]])
                {
                    return false;
                }

                // default value is 0, so we need add 1
                m1[s[i]] = i + 1;
                m2[t[i]] = i + 1;
            }
            return true;
        }
    }
}
