using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine(BinomialCal(n, k));
    }

    private static long BinomialCal(int n, int k)
    {
        if (k > n)
        {
            return 0;
        }
        if (k == n || k == 0)
        {
            return 1;
        }

        return BinomialCal(n - 1, k - 1) + BinomialCal(n - 1, k);
    }
}