using System;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parent;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parent = Enumerable.Repeat(-1, graph.Length).ToArray();

        var maxFlow = 0;
        var start = 0;
        var end = graph.Length - 1;

        while (Bfs(start,end))
        {
            var pathFlow = int.MaxValue;
            var currentNode = end;

            while (currentNode!=start)
            {
                var previous = parent[currentNode];
                var currentFlow = graph[previous][currentNode];

                if (currentFlow>0 && currentFlow < pathFlow)
                {
                    pathFlow = currentFlow;
                }

                currentNode = previous;
            }
            maxFlow += pathFlow;
            currentNode = end;

            while (currentNode!=start)
            {
                var previousNode = parent[currentNode];
                graph[previousNode][currentNode] -= pathFlow;
                graph[currentNode][previousNode] += pathFlow;

                currentNode = previousNode;
            }
        }

        return maxFlow;
    }

    private static bool Bfs(int start, int end)
    {
        var visited = new bool[graph.Length];
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count>0)
        {
            var node = queue.Dequeue();
            for (int child = 0; child < graph[node].Length; child++)
            {
                if (graph[node][child]>0 && !visited[child])
                {
                    queue.Enqueue(child);
                    parent[child] = node;
                    visited[child] = true;
                }
            }
        }

        return visited[end];
    }
}
