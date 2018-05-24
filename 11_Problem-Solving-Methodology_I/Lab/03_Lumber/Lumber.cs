using System;
using System.Collections.Generic;
using System.Linq;

class Lumber
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var logsCount = input[0];
        var queries = input[1];

        Log[] logs = new Log[logsCount + 1];
        for (int root = 1; root <= logsCount; root++)
        {
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x1 = input[0];
            var y1 = input[1];
            var x2 = input[2];
            var y2 = input[3];

            Log currentLog = new Log(x1, y1, x2, y2, root);
            logs[root] = currentLog;

            var toRedirect = new HashSet<int>();
            for (int i = 1; i < root; i++)
            {
                if (!logs[i].IsOverlapping(currentLog))
                {
                    continue;
                }

                toRedirect.Add(logs[i].Root);
            }

            for (int i = 1; i < root; i++)
            {
                if (toRedirect.Contains(logs[i].Root))
                {
                    logs[i].Root = root;
                }
            }
        }

        for (int i = 0; i < queries; i++)
        {
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var id1 = input[0];
            var id2 = input[1];

            Console.WriteLine(logs[id1].IsConnected(logs[id2]) ? "YES" : "NO");
        }
    }
}

class Log
{
    public Log(int x1, int y1, int x2, int y2, int root)
    {
        this.X1 = x1;
        this.Y1 = y1;
        this.X2 = x2;
        this.Y2 = y2;
        this.Root = root;
    }

    private int X1 { get;}

    private int Y1 { get;}

    private int X2 { get;}

    private int Y2 { get;}

    internal int Root { get; set; }

    internal bool IsOverlapping(Log other)
    {
        return this.X1 <= other.X2 &&
               other.X1 <= this.X2 &&
               this.Y1 >= other.Y2 &&
               other.Y1 >= this.Y2;
    }

    internal bool IsConnected(Log other)
    {
        return this.Root == other.Root;
    }
}