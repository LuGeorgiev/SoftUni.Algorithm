using System;
using System.Linq;

namespace DevidingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var totalSums = presents.Sum();
            var sums = new int[totalSums + 1];
            for (int i = 1; i < sums.Length; i++)
            {
                sums[i] = -1;
            }

            for (int presentIndex = 0; presentIndex < presents.Length; presentIndex++)
            {
                for (int previousSumIndex = totalSums-presents[presentIndex]; previousSumIndex >= 0; previousSumIndex--)
                {
                    if (sums[previousSumIndex]!= -1 
                        && sums[previousSumIndex+presents[presentIndex]]==-1)
                    {
                        //writes down what is the index of previous sum that led to this sum
                        sums[previousSumIndex + presents[presentIndex]] = presentIndex;
                    }
                }
            }
            var half = totalSums / 2;
            for (int i = half; i >=0 ; i--)
            {
                if (sums[i]==-1)
                {
                    continue;
                }
                Console.WriteLine($"Difference: {totalSums - i - i}");
                Console.WriteLine($"Alan:{i} Bob:{totalSums-i}");
                Console.Write("Alan takes:");
                while (i!=0)
                {
                    Console.Write($"{presents[sums[i]]} ");
                    i -= presents[sums[i]];
                }
                Console.WriteLine();
                Console.WriteLine("Bob takes the rest");
            }

        }
    }
}
