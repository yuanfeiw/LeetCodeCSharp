﻿using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new Solution().IsRectangleCover(new [,]{{0, 0, 4, 1},{7,0,8,2},{6,2,8,3},{5,1,6,3},{4,0,5,1},{6,0,7,2},{4,2,5,3},{2,1,4,3},{0,1,2,2},{0,2,2,3},{4,1,5,2},{5,0,6,1}}));
        }
    }
}
