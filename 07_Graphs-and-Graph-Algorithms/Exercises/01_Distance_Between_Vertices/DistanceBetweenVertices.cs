﻿using System;
using System.Collections.Generic;
using System.Linq;

class DistanceBetweenVertices
{
    static Dictionary<int, List<int>> graph;

    static List<int[]> pairs;

    static Dictionary<int, bool> visited;

    static void Main(string[] args)
    {
        var countOfVertices = int.Parse(Console.ReadLine());
        var countOfPairs = int.Parse(Console.ReadLine());

        InitializeGraph(countOfVertices);
        InitializePairs(countOfPairs);

        foreach (var pair in pairs)
        {
            visited = new Dictionary<int, bool>();
            foreach (var vertex in graph.Keys)
            {
                visited[vertex] = false;
            }

            int distance = CalculateShortestDistance(pair[0], pair[1]);
            Console.WriteLine($"{{{pair[0]}, {pair[1]}}} -> {distance}");
        }
    }

    private static int CalculateShortestDistance(int start, int end)
    {
        Queue<int> vertices = new Queue<int>();
        vertices.Enqueue(start);
        List<int> children;
        int distance = 1;

        while (vertices.Count > 0)
        {
            children = new List<int>();

            while (vertices.Count > 0)
            {
                var current = vertices.Dequeue();
                foreach (var child in graph[current])
                {
                    if (!visited[child])
                    {
                        if (child == end)
                        {
                            return distance;
                        }

                        visited[child] = true;
                        children.Add(child);
                    }
                }
            }

            vertices = new Queue<int>(children);
            distance++;
        }

        return -1;
    }

    private static void InitializePairs(int countOfPairs)
    {
        pairs = new List<int[]>();
        for (int i = 0; i < countOfPairs; i++)
        {
            int[] pair = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            pairs.Add(pair);
        }
    }

    private static void InitializeGraph(int countOfVertices)
    {
        graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < countOfVertices; i++)
        {
            var input = Console.ReadLine().Split(new [] {":"}, StringSplitOptions.RemoveEmptyEntries);
            var startVertix = int.Parse(input[0]);
            graph.Add(startVertix, new List<int>());

            if (input.Length > 1)
            {
                graph[startVertix] = input[1].Split().Select(int.Parse).ToList();
            }
        }
    }
}