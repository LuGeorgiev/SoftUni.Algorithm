using System;
using System.Collections.Generic;
using System.Linq;

namespace SticksFastWay
{
    class Program
    {
        static Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
        static Dictionary<int, HashSet<int>> parents = new Dictionary<int, HashSet<int>>();

        static void Main(string[] args)
        {
            var vertexCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < vertexCount; i++)
            {
                graph[i] = new HashSet<int>();
                parents[i] = new HashSet<int>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = edge[0];
                int to = edge[1];

                graph[from].Add(to);
                parents[to].Add(from);
            }

            var result = new List<int>();
            while (true)
            {
                var node = parents
                    .Where(x => parents[x.Key].Count == 0)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault();

                if (node.Value==null)
                {
                    break;
                }

                result.Add(node.Key);
                parents.Remove(node.Key);

                foreach (var child in graph[node.Key])
                {
                    parents[child].Remove(node.Key);
                }
            }

            if (parents.Count>0)
            {
                Console.WriteLine("Cannot lift all sticks");
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
