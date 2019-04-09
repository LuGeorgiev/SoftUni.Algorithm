using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visited =new HashSet<string>();
    private HashSet<string> cycleNodes =new HashSet<string>();//cycle detection

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    // DFS approach
    public ICollection<string> TopSort()
    {
        LinkedList<string> sorted = new LinkedList<string>();

        foreach (var node in graph.Keys)
        {
            DFS(node, sorted);
        }

        return sorted;
    }

    private void DFS(string node, LinkedList<string> sorted)
    {
        //cycle detection
        if (cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected");
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node); //cycle detection

            foreach (var child in graph[node])
            {
                DFS(child, sorted);
            }
            cycleNodes.Remove(node); //cycle detection
            sorted.AddFirst(node);
        }
    }

    public ICollection<string> TopSortRemoveNodeAlgo()
    {
        Dictionary<string, int> predecessorCount= GetPredecessorsCount(this.graph);
        List<string> sorted = new List<string>();

        while (true)
        {
            string nodeToRemove = predecessorCount.Keys
                .Where(x => predecessorCount[x] == 0)
                .FirstOrDefault();

            if (nodeToRemove==null)
            {
                break;
            }

            foreach (var child in graph[nodeToRemove])
            {
                predecessorCount[child]--;
            }
            predecessorCount.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);
            this.graph.Remove(nodeToRemove);
            // GetPredecessorsCount(this.graph);
        }

        if (graph.Count>0)
        {
            throw new InvalidOperationException();
        }

        return sorted;
    }

    private Dictionary<string, int> GetPredecessorsCount(Dictionary<string, List<string>> graph)
    {
        Dictionary<string, int>  predecessorCount = new Dictionary<string, int>();

        foreach (var node in graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount[node.Key] = 0;
            }

            foreach (var child in node.Value)
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    predecessorCount[child] = 0;
                }
                predecessorCount[child]++;
            }
        }

        return predecessorCount;
    }
}
