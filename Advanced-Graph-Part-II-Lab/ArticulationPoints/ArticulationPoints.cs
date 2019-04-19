using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    //Articulation point is such point that will separete the components if the given node is deleted
    //Hopcroft, Tarjan Algotithm

    private static List<int>[] graph;
    private static bool[] visited;
    private static int[] depths;
    private static int[] lowpoint;
    private static int?[] parent;

    private static List<int> articulationPoints = new List<int>();

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[targetGraph.Length];
        depths = new int[targetGraph.Length];
        lowpoint = new int[targetGraph.Length];
        parent = new int?[targetGraph.Length];

        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node])
            {
                FindArticulationPoints(node, 0);
            }
        }

        return articulationPoints;
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoint[node] = depth;

        int childCount = 0;
        bool isArtriculationPoint = false;

        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                parent[child] = node;
                FindArticulationPoints(child, depth + 1);
                childCount++;

                if (lowpoint[child] >= depths[node])
                {
                    isArtriculationPoint = true;
                }

                lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
            }
            else if (child!=parent[node])
            {
                lowpoint[node] = Math.Min(lowpoint[node], depths[child]);
            }
        }

        if ((parent[node]==null && childCount>1)
            || (parent[node]!= null && isArtriculationPoint))
        {
            articulationPoints.Add(node);
        }
    }
}
