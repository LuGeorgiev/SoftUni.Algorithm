using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        private static Dictionary<int, ulong> fibResults = new Dictionary<int, ulong>()
        {
            {0, 0 },
            {1, 1 },
            {2, 1 }
        };

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ulong fibN = CalculateFibN(n);
            Console.WriteLine(fibN);
        }

        private static ulong CalculateFibN(int n)
        {
            if (fibResults.ContainsKey(n))
            {
                return fibResults[n];
            }

            var result = CalculateFibN(n - 1) + CalculateFibN(n - 2);
            fibResults[n] = result;

            return result;
        }
    }
}
