using System;
using System.Collections.Generic;

public class KruskalAlgorithm
{
    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        edges.Sort();
        var parent = new int[numberOfVertices];
        for (int i = 0; i < numberOfVertices; i++)
        {
            parent[i] = i;
        }

        var spanningTree = new List<Edge>();
        foreach (var edge in edges)
        {
            int rootStartNode = FindRoot(edge.StartNode, parent);
            int rootEndNode = FindRoot(edge.EndNode, parent);
            if (rootEndNode != rootStartNode)
            {
                spanningTree.Add(edge);
                parent[rootEndNode] = rootStartNode;
            }
        }

        return spanningTree;
    }

    private static int FindRoot(int node, int[] parent)
    {
        int root = node;
        while (parent[root] != root)
        {
            root = parent[root];
        }

        while (node != root)
        {
            int previousParent = parent[node];
            parent[node] = root;
            node = previousParent;
        }

        return root;
    }
}