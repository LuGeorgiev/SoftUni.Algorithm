using System;
using System.Collections.Generic;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var toSort = new List<string>() { "ivan", "Ivan", "Asen", "qhick", "kIUYT" };

            var sorted = QuickSort<string>.Sort(toSort);

            Console.WriteLine(string.Join(", ", sorted));
        }

       
    }
}
