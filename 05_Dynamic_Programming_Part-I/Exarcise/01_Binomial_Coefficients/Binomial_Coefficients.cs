using System;

class Binomial_Coefficients
{
    private static long[,] memo;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        memo = new long[n + 1, k + 1];
        Console.WriteLine(BinomialCal(n, k));
    }

    private static long BinomialCal(int n, int k)
    {
        if (memo[n, k] != 0)
        {
            return memo[n, k];
        }
        if (k > n)
        {
            return 0;
        }
        if (k == n || k == 0)
        {
            return 1;
        }
        memo[n, k] = BinomialCal(n - 1, k - 1) + BinomialCal(n - 1, k);

        return memo[n, k];
    }
}