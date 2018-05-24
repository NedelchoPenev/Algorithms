using System;
using System.Linq;
using System.Text;

class Dividing_Presents
{
    private static int[] presents;
    private static int[] sums;
    static void Main(string[] args)
    {
        presents = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int total = presents.Sum();
        sums = new int[total + 1];

        for (int i = 1; i < sums.Length; i++)
        {
            sums[i] = -1;
        }

        for (int i = 0; i < presents.Length; i++)
        {
            for (int j = total; j >= 0; j--)
            {
                if (sums[j] != -1 && sums[j + presents[i]] == -1)
                {
                    sums[j + presents[i]] = i;
                }
            }
        }

        int half = total / 2;

        for (int i = half; i >= 0; i--)
        {
            if (sums[i] != -1)
            {
                var alanShare = i;
                var bobShare = total - i;
                Console.WriteLine("Difference: " + (bobShare - alanShare));
                Console.Write("Alan:" + alanShare + " ");
                Console.WriteLine("Bob:" + bobShare);
                Console.WriteLine("Alan takes: " + GetAlanPresents(alanShare));
                Console.WriteLine("Bob takes the rest.");
                break;
            }
        }
    }

    private static string GetAlanPresents(int index)
    {
        StringBuilder result = new StringBuilder();

        while (index != 0)
        {
            int value = presents[sums[index]];
            result.Append(value + " ");
            index = index - value;
        }

        return result.ToString();
    }
}