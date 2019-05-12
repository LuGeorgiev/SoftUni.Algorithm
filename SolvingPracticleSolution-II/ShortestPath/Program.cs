using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    class Program
    {
        private static char[] directions = new[] {'L','R','S'};
        private static char[] input;
        private static Queue<string> queue;
        static void Main(string[] args)
        {
            input = Console.ReadLine().ToCharArray();
            var asterixCount = input.Where(x => x == '*').Count();
            queue = new Queue<string>();

            GenerateVariationsWithRepetition(asterixCount);

            Console.WriteLine(queue.Count);
            while (queue.Count>0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void Print(int[] elements)
        {
            //Console.WriteLine(string.Join(", ",elements));
            var counter = 0;
            var result = new char[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (input[i] != '*')
                {
                    result[i] = input[i];
                }
                else
                {
                    result[i] = directions[elements[counter]];
                    counter++;
                }
            }
            queue.Enqueue(new string(result));
        }

        private static void GenerateVariationsWithRepetition(int symbolsToFill)
        {
            int n = 3;
            int k = symbolsToFill; // L R S
            int[] arr = new int[k];

            while (true)
            {
                int index = k - 1;
                Print(arr);
                while (index >= 0 && arr[index] != n - 1)
                {
                    arr[index]++;
                    Print(arr);
                }
                for (int i = index; i >= 0; i--)
                {
                    if (arr[i] >= n - 1)
                    {
                        arr[i] = 0;
                        arr[i - 1]++;
                    }
                    if (arr[i - 1] <= n - 1 || arr[0] >= n)
                    {
                        break;
                    }

                }

                if (arr[0] >= n)
                {
                    break;
                }
            }
        }
    }
}
