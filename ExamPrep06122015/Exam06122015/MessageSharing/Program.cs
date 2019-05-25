using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageSharing
{
    class Program
    {
        private static Dictionary<string, List<string>> connectionsGraph = new Dictionary<string, List<string>>();
        private static HashSet<string> visited = new HashSet<string>();
        private static HashSet<string> lastVisited;

        static void Main(string[] args)
        {
            FillInput();

            int totalPeople = connectionsGraph.Keys.Count;
            //if all visited on first step print result

            int visitCount = 0;
            while (visited.Count < totalPeople)
            {
                lastVisited = new HashSet<string>();
                int visitedCountBefore = visited.Count;
                foreach (var person in visited)
                {
                    foreach (var child in connectionsGraph[person])
                    {
                        if (!visited.Contains(child))
                        {
                            lastVisited.Add(child);
                        }
                    }
                }               
                visited.UnionWith(lastVisited);
                int visitedCountAfter = visited.Count;

                if (visitedCountAfter==visitedCountBefore)
                {
                    break;
                }

                visitCount++;
            }

            if (visitCount==0 && visited.Count == totalPeople)
            {
                Console.WriteLine($"All people reached in {visitCount} steps");
                Console.WriteLine($"People at last step: {string.Join(", ", connectionsGraph.Keys.OrderBy(x => x))}");
            }
            else if (visited.Count==totalPeople)
            {
                Console.WriteLine($"All people reached in {visitCount} steps");
                Console.WriteLine($"People at last step: {string.Join(", ", lastVisited.OrderBy(x=>x))}");
            }
            else
            {
                var notVisited = connectionsGraph.Keys
                    .Where(x => !visited.Contains(x))
                    .OrderBy(x=>x)
                    .ToArray();
                Console.WriteLine($"Cannot reach: {string.Join(", ",notVisited)}");
            }
        }

        private static void FillInput()
        {
            var people = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .Select(x => x.TrimEnd(new char[] { ',', ' ' }))
                .ToArray();
            foreach (var person in people)
            {
                connectionsGraph.Add(person, new List<string>());
            }

            var connections = Console.ReadLine()
                .Split(':')
                .Last()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();
            foreach (var connection in connections)
            {
                var token = connection
                    .Split('-')
                    .Select(x => x.Trim())
                    .ToArray();
                var from = token[0];
                var to = token[1];
                connectionsGraph[from].Add(to);
                connectionsGraph[to].Add(from);
            }

            var strtMsg = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .Select(x => x.TrimEnd(new[] { ',', ' ' }))
                .ToArray();
            foreach (var person in strtMsg)
            {
                visited.Add(person);
            }
        }
    }
}
