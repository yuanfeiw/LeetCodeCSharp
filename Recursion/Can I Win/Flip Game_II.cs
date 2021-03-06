﻿/*
294	Flip Game II $
Problem Description:

You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.

Write a function to determine if the starting player can guarantee a win.

For example, given s = "++++", return true. The starting player can guarantee a win by flipping the middle "++" to become "+--+".

Follow up:
Derive your algorithm's runtime complexity.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        // or Sprague-Grundy Function?
        public bool CanWin(string s)
        {
            return CanWin(s, new Dictionary<string, bool>());
        }

        private bool CanWin(string s, Dictionary<string, bool> cache)
        {
            if (cache.ContainsKey(s))
            {
                return cache[s];
            }

            for (int i = 0; i <= s.Length - 2; i++)
            {
                if (s[i] == '+' && s[i + 1] == '+')
                {
                    if (!CanWin(s.Substring(0, i) + "--" + s.Substring(i + 2)))
                    {
                        cache[s] = true;
                        return true;
                    }
                }
            }

            cache[s] = false;
            return false;
        }
    }
}
