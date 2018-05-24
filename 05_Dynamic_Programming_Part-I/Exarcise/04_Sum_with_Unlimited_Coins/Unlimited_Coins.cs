using System;
using System.Linq;

class Unlimited_Coins
{
    static void Main(string[] args)
    {
        var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sum = int.Parse(Console.ReadLine());
        Console.WriteLine(Count(coins, coins.Length, sum));
    }

    static long Count(int[] coins, int length, int sum)
    {
        long[] table = new long[sum + 1];

        table[0] = 1;

        for (int i = 0; i < length; i++)
        {
            for (int j = coins[i]; j <= sum; j++)
            {
                table[j] += table[j - coins[i]];
            }
        }

        return table[sum];
    }
}