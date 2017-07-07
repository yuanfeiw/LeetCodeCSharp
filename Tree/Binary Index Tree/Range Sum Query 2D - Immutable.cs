﻿/*
304	Range Sum Query 2D - Immutable
easy
Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

Range Sum Query 2D
The above rectangle (with the red border) is defined by (row1, col1) = (2, 1) and (row2, col2) = (4, 3), which contains sum = 8.

Example:
Given matrix = [
  [3, 0, 1, 4, 2],
  [5, 6, 3, 2, 1],
  [1, 2, 0, 1, 5],
  [4, 1, 0, 1, 7],
  [1, 0, 3, 0, 5]
]

sumRegion(2, 1, 4, 3) -> 8
sumRegion(1, 1, 2, 2) -> 11
sumRegion(1, 2, 2, 4) -> 12
Note:
You may assume that the matrix does not change.
There are many calls to sumRegion function.
You may assume that row1 ≤ row2 and col1 ≤ col2.
*/

namespace Demo
{
    public class NumMatrix
    {
        private int[,] matrix;
        public NumMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    matrix[i, j] += matrix[i, j - 1];
                }
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 1; i < m; i++)
                {
                    matrix[i, j] += matrix[i - 1, j];
                }
            }

            this.matrix = matrix;
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int sum = matrix[row2, col2];
            if (row1 > 0)
            {
                sum -= matrix[row1 - 1, col2];
            }

            if (col1 > 0)
            {
                sum -= matrix[row2, col1-1];
            }

            if (row1 > 0 && col1 > 0)
            {
                sum += matrix[row1 - 1, col1 - 1];
            }

            return sum;
        }
    }
}
