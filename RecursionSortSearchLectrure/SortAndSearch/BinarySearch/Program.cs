using QuickSort;
using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 4, 65, 9, 2, -12, 56, 890,2 };
            var sortedList = QuickSort<int>.Sort(list);
            Console.WriteLine(string.Join(", ", sortedList));

            var searchedIndex = BinSerach<int>.BinSearch(sortedList, 2);
            Console.WriteLine($"And the winner is: {searchedIndex}");
        }
    }
}
