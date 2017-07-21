using System;
using System.Collections.Generic;

class Program
{
    private static SortedSet<Area> areas = new SortedSet<Area>();
    private static char[,] matrix;
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        matrix = ReadLab(rows, cols);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                FindAreas(i, j);
            }
        }

        Console.WriteLine($"Total areas found: {areas.Count}");
        int positionCount = 1;
        foreach (var area in areas)
        {
            Console.WriteLine
                ($"Area #{positionCount++} at ({area.row}, {area.col}), size: {area.size}");

        }
    }

    private static void FindAreas(int row, int col)
    {
        if (!IsValid(row, col) || matrix[row, col] == '*' || matrix[row, col] == 'v')
        {
            return;
        }

        Area newArea = new Area(row, col);
        FillArea(row, col, newArea);

        areas.Add(newArea);
    }

    private static void FillArea(int row, int col, Area newArea)
    {
        if (!IsValid(row, col) || matrix[row, col] == '*' || matrix[row, col] == 'v')
        {
            return;
        }

        matrix[row, col] = 'v';
        newArea.size++;

        FillArea(row + 1, col, newArea);
        FillArea(row, col + 1, newArea);
        FillArea(row - 1, col, newArea);
        FillArea(row, col - 1, newArea);
    }

    private static bool IsValid(int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
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

    private class Area : IComparable<Area>
    {
        public int size { get; set; }

        public int row;

        public int col;

        public Area(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int CompareTo(Area other)
        {
            int comp = other.size.CompareTo(this.size);
            if (comp == 0)
            {
                comp = this.row.CompareTo(other.row);
                if (comp == 0)
                {
                    comp = this.col.CompareTo(other.col);
                }
            }

            return comp;
        }
    }
}