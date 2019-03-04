using System;
using System.Linq;

namespace VariationsWithRepetitions
{
    class Program
    {
        private static string[] elements;
        private static int[] variation;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();
            var variationLength = int.Parse(Console.ReadLine());
            variation = new int[variationLength];

            VariationsWithReps(0);
        }

        private static void VariationsWithReps(int index)
        {
            if (index >= variation.Length)
            {
                Print(variation);
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {

                    variation[index] = i;
                    VariationsWithReps(index + 1);

                }
            }
        }

        private static void Print(int[] variation)
        {
            for (int i = 0; i < variation.Length - 1; i++)
            {
                Console.Write(elements[variation[i]] + " ");
            }
            Console.WriteLine(elements[variation[variation.Length - 1]]);

        }
    }
}
