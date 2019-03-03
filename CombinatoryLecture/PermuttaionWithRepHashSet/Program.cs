using System;
using System.Collections.Generic;

namespace PermutationsWithRepHashSet
{
    class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            elements = new int[] { 1, 2, 2 };
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                var swapped = new HashSet<int>();

                for (int i = index ; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}
