﻿/*
11	Container With Most Water
Medium, math, highlow
Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water. 

Note: You may not slant the container. 
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxArea(int[] height)
        {
            int len = height.Length;
            int low = 0;
            int high = len - 1;
            int maxArea = 0;
            while (low < high)
            {
                maxArea = Math.Max(maxArea,
                    (high - low)*Math.Min(height[low], height[high]));
                if (height[low] < height[high])
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            return maxArea;
        }
    }
}
