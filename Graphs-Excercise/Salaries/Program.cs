using System;
using System.Collections.Generic;
using System.Linq;

namespace Salaries
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static int[] salaries;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            salaries = new int[numberOfNodes];
            visited = new bool[numberOfNodes];
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numberOfNodes; i++)
            {
                graph[i] = new List<int>();
            }

            for (int node = 0; node < numberOfNodes; node++)
            {
                var inputLine = Console.ReadLine().ToCharArray();
                for (int bossOf = 0; bossOf < numberOfNodes; bossOf++)
                {
                    if (inputLine[bossOf]=='Y')
                    {
                        graph[node].Add(bossOf);
                    }
                }
            }

            var employees = graph.Values
                .SelectMany(x=>x)
                .Distinct()
                .ToArray();

            var bosses = graph.Keys
                .Where(x => !employees.Contains(x))
                .ToArray();
            foreach (var boss in bosses)
            {
                visited[boss] = true;
                DFS(boss);
            }

            Console.WriteLine(salaries.Sum(x=>x));
        }

        private static void DFS(int node)
        {
            if (graph[node].Count==0)
            {
                salaries[node] = 1;
                return;
            }

            foreach (var employee in graph[node])
            {
                if (!visited[employee])
                {
                    visited[employee] = true;
                    DFS(employee);
                }
                salaries[node] += salaries[employee];
            }
        }
    }
}
