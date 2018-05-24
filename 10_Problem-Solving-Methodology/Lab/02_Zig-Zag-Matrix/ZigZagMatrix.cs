using System;
using System.Collections.Generic;
using System.Linq;

class ZigZagMatrix
{
    static void Main(string[] args)
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        var matrix = new int[rows][];
        ReadMatrix(rows, matrix);

        var maxPath = new int[rows, cols];
        var previousRowIndex = new int[rows, cols];

        for (int row = 1; row < rows; row++)
        {
            maxPath[row, 0] = matrix[row][0];
        }

        for (int col = 1; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                int previousMax = 0;

                if (col % 2 != 0)
                {
                    for (int i = row + 1; i < rows; i++)
                    {
                        if (maxPath[i, col - 1] > previousMax)
                        {
                            previousMax = maxPath[i, col - 1];
                            previousRowIndex[row, col] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < row; i++)
                    {
                        if (maxPath[i, col - 1] > previousMax)
                        {
                            previousMax = maxPath[i, col - 1];
                            previousRowIndex[row, col] = i;
                        }
                    }
                }

                maxPath[row, col] = previousMax + matrix[row][col];
            }
        }

        var currentRowIndex = GetLastRowIndexOfPath(maxPath, cols);

        var path = RecoverMaxPath(cols, matrix, currentRowIndex, previousRowIndex);

        Console.WriteLine($"{path.Sum()} = {string.Join(" + ", path)}");
    }

    private static List<int> RecoverMaxPath(int cols, int[][] matrix, int currentRowIndex, int[,] previousRowIndex)
    {
        List<int> path = new List<int>();
        var columnIndex = cols - 1;

        while (columnIndex >= 0)
        {
            path.Add(matrix[currentRowIndex][columnIndex]);
            currentRowIndex = previousRowIndex[currentRowIndex, columnIndex];
            columnIndex--;
        }

        path.Reverse();

        return path;
    }

    private static int GetLastRowIndexOfPath(int[,] maxPath, int cols)
    {
        var currentRowIndex = -1;
        var globalMax = 0;

        for (int row = 0; row < maxPath.GetLength(0); row++)
        {
            if (maxPath[row, cols -1] > globalMax)
            {
                currentRowIndex = row;
                globalMax = maxPath[row, cols - 1];
            }
        }

        return currentRowIndex;
    }

    private static void ReadMatrix(int rows, int[][] matrix)
    {
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        }
    }
}