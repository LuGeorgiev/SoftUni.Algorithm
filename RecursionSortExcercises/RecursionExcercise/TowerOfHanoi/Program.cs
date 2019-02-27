using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int discs = 3;
            var source = new Stack<int>(Enumerable.Range(1, discs).Reverse());
            var spare = new Stack<int>();
            var destination = new Stack<int>();

            PrintRods(source, spare, destination);

            MoveDiscs(discs, source, destination, spare);

        }

        private static void PrintRods(Stack<int> source, Stack<int> spare, Stack<int> destination)
        {
            Console.WriteLine($"Source: {string.Join(" ", source.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(" ", spare.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(" ", destination.Reverse())}");
            Console.WriteLine();
        }

        private static void MoveDiscs(int bottomDisc, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisc==1)
            {
                destination.Push(source.Pop());
                Console.WriteLine($"Move disc: {bottomDisc}");
                PrintRods(source, spare, destination);
            }
            else
            {
                MoveDiscs(bottomDisc - 1, source, spare, destination);
                MoveDiscs(1, source, destination, spare);
                MoveDiscs(bottomDisc - 1, spare, destination, source);
            }
        }
    }
}
