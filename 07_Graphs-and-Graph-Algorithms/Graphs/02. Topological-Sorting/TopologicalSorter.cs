using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    // private Dictionary<string, int> predecessorCount;
    private HashSet<string> visited;
    private HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        this.visited = new HashSet<string>();
        this.cycleNodes = new HashSet<string>();
    }

    public ICollection<string> TopSort()
    {
        var sorted = new LinkedList<string>();

        foreach (var node in this.graph.Keys)
        {
            this.DFS(node, sorted);
        }

        return sorted;
    }

    private void DFS(string node, LinkedList<string> sorted)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected.");
        }

        if (!this.visited.Contains(node))
        {
            this.visited.Add(node);
            this.cycleNodes.Add(node);

            foreach (var child in this.graph[node])
            {
                this.DFS(child, sorted);
            }

            this.cycleNodes.Remove(node);
            sorted.AddFirst(node);
        }
    }

    // public ICollection<string> TopSort()
    // {
    //     this.GetPredecessorCount(this.graph);
    //     var sorted = new List<string>();
    //     while (true)
    //     {
    //         string nodeToRemove = this.predecessorCount.Keys.FirstOrDefault(x => this.predecessorCount[x] == 0);
    //
    //         if (nodeToRemove == null)
    //         {
    //             break;
    //         }
    //
    //         foreach (var child in this.graph[nodeToRemove])
    //         {
    //             this.predecessorCount[child]--;
    //         }
    //         this.predecessorCount.Remove(nodeToRemove);
    //         sorted.Add(nodeToRemove);
    //     }
    //
    //     if (this.predecessorCount.Count > 0)
    //     {
    //         throw new InvalidOperationException();
    //     }
    //
    //     return sorted;
    // }

    // private void GetPredecessorCount(Dictionary<string, List<string>> graph)
    // {
    //     this.predecessorCount = new Dictionary<string, int>();
    //
    //     foreach (var node in graph)
    //     {
    //         if (!this.predecessorCount.ContainsKey(node.Key))
    //         {
    //             this.predecessorCount[node.Key] = 0;
    //         }
    //
    //         foreach (var child in node.Value)
    //         {
    //             if (!this.predecessorCount.ContainsKey(child))
    //             {
    //                 this.predecessorCount[child] = 0;
    //             }
    //
    //             this.predecessorCount[child]++;
    //         }
    //     }
    // }
}
