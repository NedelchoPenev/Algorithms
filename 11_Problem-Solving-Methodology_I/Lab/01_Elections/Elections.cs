using System;
using System.Numerics;

class Elections
{
    private static int[] parties;

    private static int k;

    static void Main(string[] args)
    {
        k = int.Parse(Console.ReadLine());
        var n = int.Parse(Console.ReadLine());

        parties = new int[n];

        int maxVotes = 0;
        for (int i = 0; i < n; i++)
        {
            parties[i] = int.Parse(Console.ReadLine());
            maxVotes += parties[i];
        }

        Array.Sort(parties);

        BigInteger[] votesDp = new BigInteger[maxVotes + 1];
        votesDp[0] = BigInteger.One;

        int mostSeats = 0;

        foreach (var partyVotes in parties)
        {
            for (int j = mostSeats + partyVotes; j >= partyVotes; j--)
            {
                if (votesDp[j - partyVotes].IsZero)
                {
                    continue;
                }

                if (mostSeats < j)
                {
                    mostSeats = j;
                }

                if (votesDp[j].IsZero)
                {
                    votesDp[j] = votesDp[j - partyVotes];
                }
                else
                {
                    votesDp[j] = votesDp[j] + (votesDp[j - partyVotes]);
                }
            }
        }

        BigInteger combinations = BigInteger.Zero;

        for (int i = k; i <= maxVotes; i++)
        {
            if (votesDp[i].IsZero)
            {
                continue;
            }

            combinations = combinations + votesDp[i];
        }

        Console.WriteLine(combinations);
    }
}