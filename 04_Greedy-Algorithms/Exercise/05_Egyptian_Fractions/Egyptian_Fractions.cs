using System;
using System.Linq;

class Egyptian_Fractions
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split('/').Select(e => int.Parse(e)).ToArray();
        int p = input[0];
        int q = input[1];

        if (p > q)
        {
            Console.WriteLine("Error (fraction is equal to or greater than 1)");
            return;
        }

        Console.Write($"{p}/{q} = ");
        if (q % p == 0)
        {
            q = q / p;
            Console.Write($"1/{q}");
            return;
        }

        while (true)
        {
            int divider = (p + q) / p;
            Console.Write($"1/{divider} + ");

            p = (p * divider) - q;
            q = q * divider;

            if (q % p == 0)
            {
                q = q / p;
                Console.Write($"1/{q}");
                break;
            }
        }
    }
}