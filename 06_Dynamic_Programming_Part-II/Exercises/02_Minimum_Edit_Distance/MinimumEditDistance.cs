using System;
using System.Collections.Generic;
using System.Linq;

class MinimumEditDistance
{
    private static int replaceCost;

    private static int insertCost;

    private static int deleteCost;

    private static int[,] editCost;

    static void Main(string[] args)
    {
        char[] delimeters = new[] { '=', ' ' };

        replaceCost = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Skip(1)
            .Select(int.Parse).ToArray()[0];
        insertCost = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Skip(1)
            .Select(int.Parse).ToArray()[0];
        deleteCost = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).Skip(1)
            .Select(int.Parse).ToArray()[0];
        string first = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[1]
            .Trim();
        string second = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[1]
            .Trim();

        Console.WriteLine(EditDistDP(first, second, first.Length, second.Length));
        Console.WriteLine();
    }

    static int Min(int x, int y, int z)
    {
        if (x <= y && x <= z) return x;
        if (y <= x && y <= z) return y;
        else return z;
    }

    static int EditDistDP(String first, String second, int firstLen, int secondLen)
    {
        editCost = new int[firstLen + 1, secondLen + 1];

        for (int row = 0; row <= firstLen; row++)
        {
            editCost[row, 0] = row * deleteCost;
        }

        for (int col = 0; col <= secondLen; col++)
        {
            editCost[0, col] = col * insertCost;
        }

        for (int i = 1; i <= firstLen; i++)
        {
            for (int j = 1; j <= secondLen; j++)
            {
                
                if (first[i - 1] == second[j - 1])
                {
                    editCost[i, j] = editCost[i - 1, j - 1];
                }
                else
                {
                    editCost[i, j] = Min(
                                         editCost[i - 1, j - 1] + replaceCost, // Replace
                                         editCost[i, j - 1] + insertCost, // Insert
                                         editCost[i - 1, j] + deleteCost); //Delete
                }
            }
        }

        for (int i = 0; i < firstLen + 1; i++)
        {
            for (int j = 0; j < secondLen + 1; j++)
            {
                Console.Write("{0,3}", editCost[i, j]);
            }

            Console.WriteLine();
        }

        return editCost[firstLen, secondLen];
    }
}