using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace XelNaga
{
    class Program
    {
        private static Dictionary<int, int> spicesCount = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Where(x => x != "-1")
                .Select(int.Parse)
                .ToArray();
            ;
            spicesCount.Add(input[0], 1);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i]==input[i-1])
                {
                    continue;
                }

                if (!spicesCount.ContainsKey(input[i]))
                {
                    spicesCount[input[i]] = 1;
                    continue;
                }

                spicesCount[input[i]]++;
            }

            long result = 0;
            foreach (var kvp in spicesCount)
            {
                result += (kvp.Key + 1) * kvp.Value;
            }

            Console.WriteLine(result);
        }
    }
}
