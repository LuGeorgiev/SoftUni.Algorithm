using System;

namespace PermutationsWithRepOptimized
{
    class Program
    {
        private static int[] elements;
        static void Main(string[] args)
        {
            elements = new[] { 5, 3, 5, 5, 1};
            Array.Sort(elements);

            Permute(0, elements.Length - 1);
        }

        private static void Permute(int start, int end)
        {
            Console.WriteLine(string.Join(" ", elements));

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (elements[left] != elements[right])
                    {
                        Swap(left, right);
                        Permute(left + 1, end);
                    }
                }

                var firstElement = elements[left];
                for (int i = left; i < end-1; i++)
                {
                    elements[i] = elements[i + 1];
                }
                elements[end] = firstElement;
            }
        }

        private static void Swap(int left, int right)
        {
            var temp = elements[left];
            elements[left] = elements[right];
            elements[right] = temp;
        }
    }
}
