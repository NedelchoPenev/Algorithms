using System;

public class Fibonacci
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] memo = new long[n + 1];
        Console.WriteLine(Fib(n, memo));
    }

    private static long Fib(int n, long[] memo)
    {
        if (memo[n] != 0)
        {
            return memo[n];
        }

        if (n <= 2)
        {
            return 1;
        }

        memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo); ;
        return memo[n];
    }
}