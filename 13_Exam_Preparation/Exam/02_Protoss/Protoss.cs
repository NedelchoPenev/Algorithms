using System;
using System.Collections.Generic;

class Protoss
{
    private static List<int>[] graph;

    private static int maxConnections = 0;

    static void Main(string[] args)
    {
        var zealotsNum = int.Parse(Console.ReadLine());

        FillTheGraph(zealotsNum);

        for (int vertex = 0; vertex < graph.Length; vertex++)
        {
            FindMaxConnections(vertex);
        }

        Console.WriteLine(maxConnections);
    }

    private static void FindMaxConnections(int vertex)
    {
        var visited = new bool[graph.Length];
        visited[vertex] = true;
        var connections = 0;
        foreach (var child in graph[vertex])
        {
            if (!visited[child])
            {
                visited[child] = true;
                connections++;
            }

            foreach (var grandChild in graph[child])
            {
                if (!visited[grandChild])
                {
                    visited[grandChild] = true;
                    connections++;
                }
            }
        }

        if (connections > maxConnections)
        {
            maxConnections = connections;
        }
    }

    private static void FillTheGraph(int zealotsNum)
    {
        graph = new List<int>[zealotsNum];
        for (int i = 0; i < zealotsNum; i++)
        {
            graph[i] = new List<int>();
            var edges = Console.ReadLine();
            for (int j = 0; j < edges.Length; j++)
            {
                if (edges[j] == 'Y')
                {
                    graph[i].Add(j);
                }
            }
        }
    }
}