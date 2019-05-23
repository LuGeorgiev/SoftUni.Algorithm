using System;

namespace ChainLighting
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int v, int w, int weight)
        {
            this.V = v;
            this.W = w;
            this.Weight = weight;
        }

        public int V { get; private set; }
        public int W { get; private set; }
        public int Weight { get; private set; }

        public int Either()
        {
            return this.V;
        }

        public int Other(int v)
        {
            if (this.V == v) return this.W;
            if (this.W == v) return this.V;

            throw new ArgumentException("Invalid edge");
        }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return string.Format($"{V}-{W} {Weight}");
        }
    }
}
