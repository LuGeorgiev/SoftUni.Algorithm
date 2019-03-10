using System;

namespace PermutationsWithoutReps
{
    class Program
    {
        private static int[] elements;
        private static bool[] used;
        private static int[] perm;

        static void Main(string[] args)
        {
            elements = new[] { 0, 1, 2 };
            used = new bool[elements.Length];
            perm = new int[elements.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index>=elements.Length)
            {
                Console.WriteLine(string.Join(" ", perm));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        perm[index] = elements[i];
                        Permute(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
