using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy
{
    class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static Dictionary<int, List<int>> disconnected = new Dictionary<int, List<int>>();
        private static HashSet<int> visited;

        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ').ToArray();
            var nodes = int.Parse(tokens[0]);
            var connections = int.Parse(tokens[1]);
            var startNode = int.Parse(tokens[2]);

            for (int i = 1; i <= nodes; i++)
            {
                graph[i] = new List<int>();
                disconnected[i] = new List<int>();
            }

            for (int i = 0; i < connections; i++)
            {
                var edgeInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var start = edgeInfo[0];
                var end = edgeInfo[1];

                graph[start].Add(end);
                graph[end].Add(start);
                disconnected[start].Add(end);
                disconnected[end].Add(start);
            }
            
            visited = new HashSet<int>();

            Dfs(startNode, startNode);

            visited = new HashSet<int>();
            var max = 0;
            foreach (var node in disconnected.Keys)
            {
                if (!visited.Contains(node))
                {
                    var totalSum = GetTotalSum(node);
                    if (totalSum>max)
                    {
                        max = totalSum;
                    }
                }
            }

            Console.WriteLine(max);
        }

        private static int GetTotalSum(int node)
        {
            visited.Add(node);
            var value = node;
            
            foreach (var child in disconnected[node])
            {
                if (!visited.Contains(child))
                {
                    value += GetTotalSum(child);
                }
            }

            return value;
        }

        private static int Dfs(int node, int parent)
        {
            var totalNodes = 1;
            visited.Add(node);

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child) && child != parent)
                {
                     var subTreeNodes = Dfs(child, node);

                    if (subTreeNodes % 2 == 0)
                    {
                        disconnected[node].Remove(child);
                        disconnected[child].Remove(node);
                    }
                    totalNodes += subTreeNodes;
                }
            }
            return totalNodes;
        }
    }
}
