using System;

namespace PermutationsWithoutRepsSwap
{
    class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            elements = new int[] { 1, 2, 3 };
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index>=elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                for (int i = index+1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
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
