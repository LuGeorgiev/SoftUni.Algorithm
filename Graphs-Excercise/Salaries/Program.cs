using System;
using System.Collections.Generic;
using System.Linq;

namespace Salaries
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static long[] salaries;
        //private static bool[] visited;

        static void Main(string[] args)
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            salaries = new long[numberOfNodes];
            //visited = new bool[numberOfNodes];
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numberOfNodes; i++)
            {
                graph[i] = new List<int>();
            }

            for (int boss = 0; boss < numberOfNodes; boss++)
            {
                var inputLine = Console.ReadLine();
                for (int bossOf = 0; bossOf < numberOfNodes; bossOf++)
                {
                    if (inputLine[bossOf]=='Y')
                    {
                        graph[boss].Add(bossOf);
                    }
                }
            }

            var employees = graph.Values
                .SelectMany(x=>x)
                .Union(graph.Keys)
                .Distinct()
                .ToArray();

            foreach (var employee in employees)
            {
                DFS(employee);
            }

            //var bosses = graph.Keys
            //    .Where(x => !employees.Contains(x))
            //    .ToArray();
            //foreach (var boss in bosses)
            //{
            //    visited[boss] = true;
            //    DFS(boss);
            //}

            Console.WriteLine(salaries.Sum(x=>x));
        }

        private static void DFS(int node)
        {
            if (salaries[node]==0)
            {                
                if (graph[node].Count>0)
                {
                    foreach (var employee in graph[node])
                    {
                        DFS(employee);
                        salaries[node] += salaries[employee];
                    }
                }
                else
                {
                    salaries[node] = 1;
                }
            }

            
            //if (graph[node].Count==0)
            //{
            //    salaries[node] = 1;
            //    return;
            //}

            //foreach (var employee in graph[node])
            //{
            //    if (!visited[employee])
            //    {
            //        visited[employee] = true;
            //        DFS(employee);
            //    }
            //    salaries[node] += salaries[employee];
            //}
        }
    }
}
