namespace Kurskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            var mst = new List<Edge>();
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }
            var sortedEdges = edges
                .OrderBy(x => x.Weight)
                .ToArray();
            foreach (var edge in sortedEdges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootEndNode!=rootStartNode)
                {
                    mst.Add(edge);
                    parent[rootStartNode] = rootEndNode;
                }

            }

            return mst;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root]!=root)
            {
                root = parent[root];
            }
            return root;
        }
    }
}
