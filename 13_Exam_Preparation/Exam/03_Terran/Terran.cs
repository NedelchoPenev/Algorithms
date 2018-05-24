using System;
using System.Numerics;

class Terran
{
    private const int MaxChar = 26;

    static void Main(string[] args)
    {
        var input = Console.ReadLine().Trim().ToCharArray();

        Console.WriteLine(CountDistinctPermutations(input));
    }

    static BigInteger CountDistinctPermutations(char[] str)
    {
        int length = str.Length;
	
        int[] freq = new int[MaxChar];

        for (int i = 0; i < length; i++)
        {
            if (str[i] >= 'A')
            {
                freq[str[i] - 'A']++;
            }
        }

        BigInteger fact = new BigInteger(1);
        for (int i = 0; i < MaxChar; i++)
        {
            fact = fact * Factorial(freq[i]);
        }

        return Factorial(length) / fact;
    }

    static BigInteger Factorial(int n)
    {
        BigInteger fact = new BigInteger(1);
        for (int i = 2; i <= n; i++)
        {
            fact = fact * i;
        }

        return fact;
    }
}