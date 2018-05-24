using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Move_Down_Right
{
    private static int[,] matrix;

    private static int[,] memo;

    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        memo = new int[rows, cols];

        FillMatrix(rows, cols);
        FillMemo();
        PrintPath();

    }

    private static void PrintPath()
    {
        List<string> result = new List<string>();
        int x = memo.GetLength(0) - 1;
        int y = memo.GetLength(1) - 1;

        while (x >= 0 && y >= 0)
        {
            result.Add($"[{x}, {y}]");
            if (x == 0)
            {
                y--;
            }
            else if (y == 0)
            {
                x--;
            }
            else
            {
                if (memo[x - 1, y] > memo[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
        }

        result.Reverse();
        Console.WriteLine(string.Join(" ", result));
    }

    private static void FillMemo()
    {
        memo[0, 0] = matrix[0, 0];

        for (int i = 1; i < memo.GetLength(0); i++)
        {
            memo[0, i] = memo[0, i - 1] + matrix[0, i];
        }

        for (int i = 1; i < memo.GetLength(1); i++)
        {
            memo[i, 0] = memo[i - 1, 0] + matrix[i, 0];
        }

        for (int i = 1; i < memo.GetLength(0); i++)
        {
            for (int j = 1; j < memo.GetLength(1); j++)
            {
                memo[i, j] = Math.Max(memo[i, j - 1], memo[i - 1, j]) + matrix[i, j];
            }
        }
    }

    private static void FillMatrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < line.Length; col++)
            {
                matrix[row, col] = line[col];
            }
        }
    }
}