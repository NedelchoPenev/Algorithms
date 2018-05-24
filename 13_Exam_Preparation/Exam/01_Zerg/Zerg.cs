using System;
using System.Linq;
using System.Numerics;

class Zerg
{
    static void Main(string[] args)
    {
        var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = matrixSize[0];
        var m = matrixSize[1];

        var mainBase = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var hx = mainBase[0];
        var hy = mainBase[1];

        var numberOfEnemies = int.Parse(Console.ReadLine());

        BigInteger[,] count = new BigInteger[n, m];

        for (int i = 0; i < numberOfEnemies; i++)
        {
            var enemiesTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var eRow = enemiesTokens[0];
            var eCol = enemiesTokens[1];
            count[eRow, eCol] = -1;
        }

        bool doge = false;
        for (int i = 0; i < n; i++)
        {
            if (count[i, 0] != -1 && !doge)
            {
                count[i, 0] = 1;
            }
            else
            {
                doge = true;
                count[i, 0] = 0;
            }
        }

        doge = false;
        for (int j = 0; j < m; j++)
        {
            if (count[0, j] != -1 && !doge)
            {
                count[0, j] = 1;
            }
            else
            {
                doge = true;
                count[0, j] = 0;
            }
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                if (count[i, j] != -1)
                {
                    count[i, j] = count[i - 1, j] + count[i, j - 1];
                }
                else
                {
                    count[i, j] = 0;
                }
            }
        }

        Console.WriteLine(count[hx, hy]);
    }
}