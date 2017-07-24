﻿/*
505	The Maze II
There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.

Given the ball's start position, the destination and the maze, find the shortest distance for the ball to stop at the destination. The distance is defined by the number of empty spaces traveled by the ball from the start position (excluded) to the destination (included). If the ball cannot stop at the destination, return -1.

The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space. You may assume that the borders of the maze are all walls. The start and destination coordinates are represented by row and column indexes.

Example 1

Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (4, 4)

Output: 12
Explanation: One shortest way is : left -> down -> left -> down -> right -> down -> right.
             The total distance is 1 + 1 + 3 + 1 + 2 + 2 + 2 = 12.


 

Example 2

Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (3, 2)

Output: -1
Explanation: There is no way for the ball to stop at the destination.


 

Note:

There is only one ball and one destination in the maze.
Both the ball and the destination exist on an empty space, and they will not be at the same position initially.
The given maze does not contain border (like the red rectangle in the example pictures), but you could assume the border of the maze are all walls.
The maze contains at least 2 empty spaces, and both the width and height of the maze won't exceed 100. 
*/

using System.Collections.Generic;

namespace Demo
{
   public partial class  Solution
   {
        public int ShortestDistance(int[,] maze, int[] start, int[] destination)
        {
            int m = maze.GetLength(0);
            int n = maze.GetLength(1);
            if (m == 0 || n == 0) return 0;

            // calc distance not steps
            var dists = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dists[i, j] = int.MaxValue;
                }
            }

            var dirs = new[] { new[] { 0, -1 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 1, 0 } };
            var q = new Queue<int[]>();
            q.Enqueue(start);
            dists[start[0], start[1]] = 0;
            while (q.Count != 0)
            {
                var t = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int x = t[0];
                    int y = t[1];
                    int dist = dists[t[0], t[1]];
                    while (x >= 0 && x < m && y >= 0 && y < n && maze[x, y] == 0)
                    {
                        dist++;
                        x += dir[0];
                        y += dir[1];
                    }

                    x -= dir[0];
                    y -= dir[1];
                    dist--;

                    if (dist < dists[x, y])
                    {
                        dists[x, y] = dist;
                        if (!(x == destination[0] && y == destination[1]))
                        {
                            q.Enqueue(new[] {x, y});
                        }
                    }
                }
            }

            int res = dists[destination[0], destination[1]];
            return (res == int.MaxValue) ? -1 : res;
        }
    }
}
