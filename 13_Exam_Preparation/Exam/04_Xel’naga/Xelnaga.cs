using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Xelnaga
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Dictionary<int, int> numbers = new Dictionary<int, int>();
        int index = 0;
        while (input[index] != -1)
        {
            if (!numbers.ContainsKey(input[index]))
            {
                numbers[input[index]] = 0;
            }

            numbers[input[index]]++;
            index++;
        }

        // for (int i = 0; i < input.Length - 1; i++)
        // {
        //     if (!numbers.ContainsKey(input[i]))
        //     {
        //         numbers[input[i]] = 0;
        //     }
        //
        //     numbers[input[i]]++;
        // }

        BigInteger result = BigInteger.Zero;
        foreach (var number in numbers.Keys.ToArray())
        {
            if (number == 0)
            {
                result++;
                continue;
            }
            var remainder = numbers[number] % number;

            if (remainder != 0)
            {
                var i = numbers[number] / (number + 1);
                result += i * (number + 1);
                numbers[number] = remainder;
                result += number + 1;
            }
            else
            {
                result += number + 1;
            }
        }

        Console.WriteLine(result);
    }
}