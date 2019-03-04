using System;
using System.Linq;

namespace VariationsWithoutReps
{
    class Program
    {
        private static string[] elements;
        private static int[] variation;
        private static bool[] usedElements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();
            var variationLength = int.Parse(Console.ReadLine());
            variation = new int[variationLength];
            usedElements = new bool[elements.Length];

            Variation(0);
        }

        private static void Variation(int index)
        {
            if (index>=variation.Length)
            {
                Print(variation);
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!usedElements[i])
                    {
                        usedElements[i] = true;
                        variation[index] = i;
                        Variation(index + 1);
                        usedElements[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] variation)
        {
            for (int i = 0; i < variation.Length-1; i++)
            {               
                Console.Write(elements[variation[i]] + " ");
            }
            Console.WriteLine(elements[variation[variation.Length-1]] );

        }
    }
}
