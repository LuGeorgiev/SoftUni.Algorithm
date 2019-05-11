using System;
using System.Collections.Generic;
using System.Linq;

namespace Lumber
{
    class Program
    {
        static List<int>[] graph;
        static void Main(string[] args)
        {
            //Read Input
            var info = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var nodes = info[0];
            var bevers = info[1];
            graph = new List<int>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
            }

            var lumberLogs = new List<Rectangle>();
            for (int i = 0; i < nodes; i++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var currentlumberLog = new Rectangle(i, tokens[0], tokens[1], tokens[2], tokens[3]);
                lumberLogs.Add(currentlumberLog);
            }


            //BUild Graph
            foreach (var currentLog in lumberLogs)
            {
                foreach (var nextLog in lumberLogs)
                {
                    if (currentLog!=nextLog)
                    {
                        if (currentLog.AreRectanglesIntersected(nextLog))
                        {
                            graph[currentLog.Id].Add(nextLog.Id);
                        }
                    }
                }
            }
            var connectedLogs = StronglyConnectedComponnet.FindStronglyConnectedComponents(graph);
                       
            
            for (int i = 0; i < bevers; i++)
            {
                var beversPath = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                int start = beversPath[0] - 1;
                int end = beversPath[1] - 1;

                var groupOfLogsFofStart = connectedLogs
                    .FirstOrDefault(x => x.Contains(start));
                if (groupOfLogsFofStart.Contains(end))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }                    
            }

        }

    }
    
}
