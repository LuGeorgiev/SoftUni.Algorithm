namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(
            Dictionary<Node, Dictionary<Node, int>> graph, 
            Node sourceNode, 
            Node destinationNode)
        {
            int?[] previous = new int?[graph.Count];
            bool[] visited = new bool[graph.Count];
            var priorityQueue = new PriorityQueue<Node>();

            foreach (var kvp in graph)
            {
                kvp.Key.DistanceFromStart = double.PositiveInfinity;
            }
            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            visited[sourceNode.Id] = true;
            while (priorityQueue.Count>0)
            {
                var curentNode = priorityQueue.ExtractMin();

                if (curentNode.CompareTo(destinationNode)==0)
                {
                    break;
                }

                foreach (var edge in graph[curentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    var distance = curentNode.DistanceFromStart + graph[curentNode][edge.Key];
                    if (distance<edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;
                        previous[edge.Key.Id] = curentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            var path = new List<int>();
            int? current = destinationNode.Id;
            while (current!=null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }
            path.Reverse();

            return path;
        }
    }
}
