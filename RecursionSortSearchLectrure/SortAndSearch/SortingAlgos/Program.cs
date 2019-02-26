using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Mergesort<int>.Merge(new[] { 4,6,3,9,-1,-900, 21 });
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
