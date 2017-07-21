using System;
using System.Collections.Generic;

class Program
{
    private const int Size = 8;
    static bool[,] chessboard = new bool[Size, Size];
    static HashSet<int> attackedRows = new HashSet<int>();
    static HashSet<int> attackedCols = new HashSet<int>();
    static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
    static HashSet<int> attackedRightDiagonals = new HashSet<int>();

    private static int solutionsFound = 0;

    static void Main(string[] args)
    {
        PutQueen(0);
    }

    static void PutQueen(int row)
    {
        if (row == Size)
        {
            PrintSolution();
        }
        else
        {
            for (int col = 0; col < Size; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    MarkAllAttackedPositions(row, col);
                    PutQueen(row + 1);
                    UnmarkAllAttackedPositions(row, col);
                }
            }
        }
    }

    private static void UnmarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Remove(row);
        attackedCols.Remove(col);
        attackedLeftDiagonals.Remove(row - col);
        attackedRightDiagonals.Remove(row + col);
        chessboard[row, col] = false;
    }

    private static void MarkAllAttackedPositions(int row, int col)
    {
        attackedRows.Add(row);
        attackedCols.Add(col);
        attackedLeftDiagonals.Add(row - col);
        attackedRightDiagonals.Add(row + col);
        chessboard[row, col] = true;
    }

    private static bool CanPlaceQueen(int row, int col)
    {
        return !attackedRows.Contains(row) && 
            !attackedCols.Contains(col) && 
            !attackedLeftDiagonals.Contains(row - col) && 
            !attackedRightDiagonals.Contains(row + col);
    }

    private static void PrintSolution()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                Console.Write(chessboard[row, col] ? "* " : "- ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        solutionsFound++;
    }
}