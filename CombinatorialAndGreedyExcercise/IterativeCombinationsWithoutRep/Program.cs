using System;
using System.Collections.Generic;
using System.Linq;

namespace IterativeCombinationsWithoutRep
{
    class Program
    {
        private static string[] elements; 

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').ToArray();
            var k = int.Parse(Console.ReadLine());

            foreach (var combo in Combinations(k, elements.Length))
            {
                PrintCombination(combo);
            }
        }

        private static void PrintCombination(int[] combo)
        {
            for (int i = 0; i < combo.Length - 1; i++)
            {
                Console.Write(elements[combo[i]] + " ");
            }
            Console.Write(elements[combo[combo.Length - 1]]);
            Console.WriteLine();
        }

        private static IEnumerable<int[]> Combinations(int k, int n)
        {
            var result = new int[k];
            var stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
