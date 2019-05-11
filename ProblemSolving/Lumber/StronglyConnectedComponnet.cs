using System.Collections.Generic;
using System.Linq;

namespace Lumber
{
    class StronglyConnectedComponnet
    {
        private static List<int>[] graph;
        private static List<int>[] reveresedGraph;
        private static bool[] visited;
        private static Stack<int> stack = new Stack<int>();

        private static List<List<int>> stronglyConnectedComponents;

        public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
        {
            graph = targetGraph;
            visited = new bool[graph.Length];
            BuildReveresdGraph();

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    Dfs(node);
                }
            }

            stronglyConnectedComponents = new List<List<int>>();
            visited = new bool[graph.Length];
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (!visited[node])
                {
                    stronglyConnectedComponents.Add(new List<int>());
                    ReversedDfs(node);
                }
            }
            return stronglyConnectedComponents;
        }

        private static void BuildReveresdGraph()
        {
            reveresedGraph = new List<int>[graph.Length];
            for (int node = 0; node < reveresedGraph.Length; node++)
            {
                reveresedGraph[node] = new List<int>();
            }

            for (int node = 0; node < graph.Length; node++)
            {
                foreach (var child in graph[node])
                {
                    reveresedGraph[child].Add(node);
                }
            }
        }

        private static void ReversedDfs(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;
                stronglyConnectedComponents.Last().Add(node);

                foreach (var child in reveresedGraph[node])
                {
                    ReversedDfs(child);
                }
            }
        }

        private static void Dfs(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;

                foreach (var child in graph[node])
                {
                    Dfs(child);
                }
                stack.Push(node);
            }
        }
    }
}
