using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingRange
{
    class Program
    {
        private static int[] elements;

        private static int targetSum;

        private static HashSet<string> finalPermutation = new HashSet<string>();

        static void Main(string[] args)
        {
            ReadElements();
            targetSum = int.Parse(Console.ReadLine());
            Permute(0);

            foreach (var permutation in finalPermutation)
            {
                Console.WriteLine(permutation);
            }
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                PrintIfTargetReached();
            }
            else
            {
                Permute(index + 1);

                for (int current = index + 1; current < elements.Length; current++)
                {
                    Swap(index, current);
                    Permute(index + 1);
                    Swap(index, current);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        private static void ReadElements()
            => elements = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        private static void PrintIfTargetReached()
        {

            int curentSum = 0;
            for (int i = 1; i <= elements.Length; i++)
            {
                curentSum += elements[i - 1] * i;
                if (curentSum == targetSum)
                {
                    var result = string.Join(" ", elements).Substring(0, 2 * i - 1);
                    finalPermutation.Add(result);

                    return;
                }
                else if (curentSum > targetSum)
                {
                    return;
                }
            }
        }

    }
}
