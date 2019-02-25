using System;

namespace GenerateVectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int bits = int.Parse(Console.ReadLine());
            GenerateVectors(bits);
        }

        private static void GenerateVectors(int bits)
        {
            GenerateVector(new int[bits], 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join("", vector));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    vector[index] = i;
                    GenerateVector(vector, index + 1);
                }
            }
        }
    }
}
