using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<char> path = new List<char>();

    private static char[,] lab;

    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        lab = ReadLab(rows, cols);
        FindPath(0, 0, 'S');
    }

    private static void FindPath(int row, int col, char direction)
    {
        if (!IsValid(row, col))
        {
            return;
        }

        path.Add(direction);

        if (lab[row, col] == 'e')
        {
            Console.WriteLine(String.Join("", path.Skip(1)));
        }
        else if (!IsVisited(row, col))
        {
            lab[row, col] = 'v';
            FindPath(row, col + 1, 'R');
            FindPath(row + 1, col, 'D');
            FindPath(row, col - 1, 'L');
            FindPath(row - 1, col, 'U');
            lab[row, col] = '-';
        }

        path.RemoveAt(path.Count - 1);
    }

    private static bool IsVisited(int row, int col)
    {
        return lab[row, col] == 'v';
    }

    private static bool IsValid(int row, int col)
    {
        return row >= 0 && row < lab.GetLength(0)
               && col >= 0 && col < lab.GetLength(1)
               && lab[row, col] != '*';
    }

    private static char[,] ReadLab(int rows, int cols)
    {
        char[,] lab = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int col = 0; col < cols; col++)
            {
                lab[row, col] = line[col];
            }
        }

        return lab;
    }
}