using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parent;
    private static int[] depths;
    private static int[] lowpoint;
    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        var graphLength = graph.Length;
        visited = new bool[graphLength];
        parent = new int?[graphLength];
        depths = new int[graphLength];
        lowpoint = new int[graphLength];
        articulationPoints = new List<int>();

        FindArticulationPoints(0, 0);

        return articulationPoints;
    }

    public static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoint[node] = depth;

        int childCount = 0;
        bool isArticulation = false;

        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                parent[child] = node;
                FindArticulationPoints(child, depth + 1);
                childCount++;

                if (lowpoint[child] >= depths[node])
                {
                    isArticulation = true;
                }

                lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
            }
            else if (parent[node] != child)
            {
                lowpoint[node] = Math.Min(lowpoint[node], depths[child]);
            }
        }

        if ((parent[node] != null && isArticulation) || parent[node] == null && childCount > 1)
        {
            articulationPoints.Add(node);
        }
    }
}