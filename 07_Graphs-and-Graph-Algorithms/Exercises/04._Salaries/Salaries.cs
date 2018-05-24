using System;
using System.Collections.Generic;
using System.Linq;

class Salaries
{
    private static List<int>[] graph;

    private static bool[] visited;

    private static Dictionary<int, long> salaries;

    static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        graph = new List<int>[lines];

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine();
            graph[i] = new List<int>();
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'Y')
                {
                    graph[i].Add(j);
                }
            }
        }

        visited = new bool[lines];
        salaries = new Dictionary<int, long>();
        for (int vertex = 0; vertex < graph.Length; vertex++)
        {
            if (!visited[vertex])
            {
                DFS(vertex);
            }
        }

        Console.WriteLine(salaries.Values.Sum());
    }

    private static void DFS(int vertex)
    {
        visited[vertex] = true;

        if (graph[vertex].Count == 0)
        {
            salaries[vertex] = 1;
        }
        else
        {
            long tempSalary = 0;
            foreach (var child in graph[vertex])
            {
                if (!visited[child])
                {
                    DFS(child);
                }

                tempSalary += salaries[child];
            }

            salaries[vertex] = tempSalary;
        }
    }
}