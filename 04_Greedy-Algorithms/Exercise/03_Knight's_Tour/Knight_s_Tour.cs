using System;
using System.Text;

class Knight_s_Tour
{
    private static int[] moveX = new int[] { 1, -1, 1, -1, 2, 2, -2, -2 };
    private static int[] moveY = new int[] { 2, +2, -2, -2, 1, -1, 1, -1 };

    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        int[,] chessboard = new int[n, n];

        int i = 1;
        int x = 0;
        int y = 0;

        while (i <= n*n)
        {
            chessboard[x, y] = i;

            int[] nextStepCoordinates = FindNextStep(chessboard, x, y);
            x = nextStepCoordinates[0];
            y = nextStepCoordinates[1];
            i++;
        }

        StringBuilder sb = new StringBuilder();
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < n; k++)
            {
                sb.Append($"{chessboard[j, k].ToString().PadLeft(3, ' ')} ");
            }
            sb.Append("\n");
        }

        Console.WriteLine(sb.ToString());
    }

    private static int[] FindNextStep(int[,] chessboard, int x, int y)
    {
        int minSteps = Int32.MaxValue;
        int[] coordinates = new int[]{x, y};

        for (int i = 0; i < 8; i++)
        {
            if (x + moveX[i] < chessboard.GetLength(0) && x + moveX[i] >= 0 &&
                y + moveY[i] < chessboard.GetLength(1) && y + moveY[i] >= 0
                && chessboard[x + moveX[i], y + moveY[i]] == 0)
            {
                int steps = CountPossibleSteps(chessboard, x + moveX[i], y + moveY[i]);
                if (steps < minSteps)
                {
                    minSteps = steps;
                    coordinates[0] = x + moveX[i];
                    coordinates[1] = y + moveY[i];
                }
            }
        }

        return coordinates;
    }

    private static int CountPossibleSteps(int[,] chessboard, int x, int y)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            if (x + moveX[i] < chessboard.GetLength(0) && x + moveX[i] >= 0 &&
                y + moveY[i] < chessboard.GetLength(1) && y + moveY[i] >= 0
                && chessboard[x + moveX[i], y + moveY[i]] == 0)
            {
                count++;
            }
        }

        return count;
    }
}