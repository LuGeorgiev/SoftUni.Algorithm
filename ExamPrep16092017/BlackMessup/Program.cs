using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackMessup
{
    class Program
    {
        class Atom : IComparable<Atom>
        {
            public Atom(string name, int mass, int decay)
            {
                this.Name = name;
                this.Mass = mass;
                this.Decay = decay;
            }

            public string Name { get; private set; }
            public int Mass { get; private set; }
            public int Decay { get; private set; }

            public int CompareTo(Atom other)
                => -this.Mass.CompareTo(other.Mass);
        }

        private static Dictionary<string, Atom> atomsByName = new Dictionary<string, Atom>();
        private static Dictionary<string, SortedSet<string>> graph = new Dictionary<string, SortedSet<string>>();

        static void Main(string[] args)
        {
            var atoms = int.Parse(Console.ReadLine());
            var connections = int.Parse(Console.ReadLine());

            for (int i = 0; i < atoms; i++)
            {
                var tokens = Console.ReadLine().Split(' ').ToArray();
                var name = tokens[0];
                var mass = int.Parse(tokens[1]);
                var decay = int.Parse(tokens[2]);
                graph[name] = new SortedSet<string>();

                atomsByName[name] = new Atom(name, mass, decay);
            }
            for (int i = 0; i < connections; i++)
            {
                var tokens = Console.ReadLine().Split(' ').ToArray();
                var from = tokens[0];
                var to = tokens[1];
                              
                graph[from].Add(to);
                graph[to].Add(from);
            }

            var molecules = FindConnectedComponent();

            Console.WriteLine(FindBestMoleculeValue(molecules));
            
        }

        static int FindBestMoleculeValue(List<SortedSet<Atom>> molecules)
        {
            var max = 0;
            foreach (var molecule in molecules)
            {
                var score = GetValue(molecule);
                if (score > max)
                {
                    max = score;
                }
            }
            return max;
        }

        private static int GetValue(SortedSet<Atom> molecule)
        {
            var maxDecay = 1;
            var score = 0;
            var count = 0;

            foreach (var atom in molecule)
            {
                if (atom.Decay > maxDecay)
                {
                    maxDecay = atom.Decay;
                    score += atom.Mass;
                    count++;
                }
                else if (maxDecay > count)
                {
                    score += atom.Mass;
                    count++;
                }
            }

            return score;
        }

        static List<SortedSet<Atom>> FindConnectedComponent()
        {
            var molecules = new List<SortedSet<Atom>>();
            var visited = new HashSet<string>();
            var index = 0;

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    molecules.Add(new SortedSet<Atom>());
                    Dfs(node, node, visited, molecules, index);
                    index++;
                }
            }

            return molecules;
        }

        static void Dfs(string node, string parent,HashSet<string> visited, List<SortedSet<Atom>> molecules, int index)
        {
            visited.Add(node);
            molecules[index].Add(atomsByName[node]);

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child) && child != parent)
                {

                    Dfs(child, node, visited, molecules,index);
                }
            }
        }
    }
}
