using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(new[] {1,2,3,4 }));
        }

        private static int Sum(int[] array)
        {
            int sum = Sum(array, 0);

            return sum;
        }
        private static int Sum(int[] array, int index)
        {
            if (index==array.Length)
            {
                return 0;
            }
            int sum = Sum(array, index + 1) + array[index];

            return sum;
        }

    }
}
