﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CyclesInGraph
{
    //Write a program to check whether an undirected graph is acyclic or holds any cycles

    class Program
    {
        static Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        static HashSet<char> visitedNodes ;

        static void Main(string[] args)
        {
            while (true)
            {
                var edge = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(edge))
                {
                    break;
                }
                var edgeData = edge.Split('-').ToArray();
                var start = edgeData[0][0];
                var end = edgeData[1][0];

                if (!graph.ContainsKey(start))
                {
                    graph[start] = new List<char>();
                }
                if (!graph.ContainsKey(end))
                {
                    graph[end] = new List<char>();
                }
                graph[start].Add(end);
                graph[end].Add(start);
            }

            bool isAcyclical = true;
            foreach (var node in graph.Keys)
            {
                visitedNodes = new HashSet<char>();
                if (!visitedNodes.Contains(node))
                {
                    visitedNodes.Add(node);
                    if (!IsAcyclicalBFS(node, visitedNodes))
                    {
                        isAcyclical = false;
                        break;
                    }
                }
            }

            if (isAcyclical)
            {
                Console.WriteLine("Acyclic: Yes");
            }
            else
            {
                Console.WriteLine("Acyclic: No");
            }
        }

        private static bool IsAcyclicalBFS(char node, HashSet<char> visited)
        {
            var queue = new Queue<char>();
            queue.Enqueue(node);
            while (queue.Count>0)
            {
                var currentNode = queue.Dequeue();
                foreach (var child in graph[currentNode])
                {
                    if (child==node)
                    {
                        return false;
                    }

                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
            return true;
        }
    }
}
