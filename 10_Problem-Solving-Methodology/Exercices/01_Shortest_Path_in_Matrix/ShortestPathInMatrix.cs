using System;
using System.Collections.Generic;
using System.Linq;

class ShortestPathInMatrix
{
    static void Main(string[] args)
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        var matrix = new int[rows, cols];

        ReadMarix(rows, matrix);

        var path = DijkstraAlgorithm(matrix, 0, 0, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);

        Console.WriteLine("Length: " + path.Sum());
        Console.WriteLine("Path: " + string.Join(" ", path));
    }

    private static void ReadMarix(int rows, int[,] matrix)
    {
        for (int i = 0; i < rows; i++)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < input.Length; j++)
            {
                matrix[i, j] = input[j];
            }
        }
    }

    public static List<int> DijkstraAlgorithm(
        int[,] graph,
        int sourceRow,
        int sourceColumn,
        int destinationRow,
        int destinationColumn)
    {
        int n = graph.GetLength(0);
        int m = graph.GetLength(1);

        var distance = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                distance[i, j] = int.MaxValue;
            }
        }

        distance[sourceRow, sourceColumn] = 0;

        Tuple<int, int>[,] previous = new Tuple<int, int>[n, m];
        var currentCell = new Tuple<int, int>(sourceRow, sourceColumn);
        previous[0, 0] = currentCell;
        bool[,] used = new bool[n, m];

        Tuple<int, int>[] neigbourCells = new Tuple<int, int>[4]
                                              {
                                                  new Tuple<int, int>(0, 1),
                                                  new Tuple<int, int>(1, 0),
                                                  new Tuple<int, int>(-1, 0),
                                                  new Tuple<int, int>(0, -1)
                                              };

        while (true)
        {
            int minDistance = int.MaxValue;
            Tuple<int, int> nextCell = null; 
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (!used[row, col] && distance[row, col] < minDistance)
                    {
                        minDistance = distance[row, col];
                        nextCell = new Tuple<int, int>(row, col);
                    }
                }
            }

            if (minDistance == int.MaxValue)
            {
                break;
            }

            used[nextCell.Item1, nextCell.Item2] = true;

            foreach (var cell in neigbourCells)
            {
                var row = nextCell.Item1 + cell.Item1;
                var column = nextCell.Item2 + cell.Item2;
                if (row >= 0 && row < n && column >= 0 && column < m)
                {
                    var newDistance = distance[nextCell.Item1, nextCell.Item2] + graph[row, column];
                    if (newDistance < distance[row, column])
                    {
                        distance[row, column] = newDistance;
                        previous[row, column] = nextCell;
                    }
                }
            }
        }

        if (distance[destinationRow, destinationColumn] == int.MaxValue)
        {
            return null;
        }

        var path = new List<int>();
        path.Add(graph[destinationRow, destinationColumn]);
        var currentNode = previous[destinationRow, destinationColumn];
        while (currentNode.Item1 != 0 || currentNode.Item2 != 0)
        {
            path.Add(graph[currentNode.Item1, currentNode.Item2]);
            currentNode = previous[currentNode.Item1, currentNode.Item2];
        }

        path.Add(graph[sourceRow, sourceColumn]);

        path.Reverse();

        return path;
    }
}