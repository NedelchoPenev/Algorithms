using System;
using System.Collections.Generic;
using System.Linq;

class AreasInMatrix
{
    private static bool[,] visited;

    private static Dictionary<char, int> areas;

    private static char[,] matrix;

    static void Main(string[] args)
    {
        var rows = int.Parse(Console.ReadLine());

        FillMatrix(rows);

        areas = new Dictionary<char, int>();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    if (!areas.ContainsKey(matrix[row, col]))
                    {
                        areas[matrix[row, col]] = 0;
                    }

                    TraverseMatrix(row, col, matrix[row, col]);
                    areas[matrix[row, col]]++;
                }
            }
        }

        Console.WriteLine($"Areas: {areas.Values.Sum()}");
        foreach (var pair in areas.OrderBy(a => a.Key))
        {
            Console.WriteLine($"Letter '{pair.Key}' -> {pair.Value}");
        }
    }

    private static void TraverseMatrix(int row, int col, char ch)
    {
        if ((row >= 0 && row < matrix.GetLength(0)) &&
            (col >= 0 && col < matrix.GetLength(1)) && 
            visited[row, col] == false &&
            ch == matrix[row, col])
        {
            visited[row, col] = true;
            TraverseMatrix(row - 1, col, ch);
            TraverseMatrix(row + 1, col, ch);
            TraverseMatrix(row, col - 1, ch);
            TraverseMatrix(row, col + 1, ch);
        }
    }

    private static void FillMatrix(int rows)
    {
        var input = Console.ReadLine();
        matrix = new char[rows, input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            matrix[0, i] = input[i];
        }

        for (int i = 1; i < rows; i++)
        {
            input = Console.ReadLine();
            for (int j = 0; j < input.Length; j++)
            {
                matrix[i, j] = input[j];
            }
        }

        visited = new bool[rows, input.Length];
    }
}