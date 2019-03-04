using System;

namespace CombinationsWithoutRepes
{
    class Program
    {
        private static int[] arr;
        private static int elements;

        static void Main(string[] args)
        {
            elements = int.Parse(Console.ReadLine()); // k <= n
            int k = int.Parse(Console.ReadLine());
            arr = new int[k];

            Combinations(0, 0);
        }

        private static void Combinations(int index, int start)
        {
            if (index>=arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = start; i < elements; i++)
                {
                    arr[index] = i;
                    Combinations(index + i, i+1);
                }
            }
        }
    }
}
