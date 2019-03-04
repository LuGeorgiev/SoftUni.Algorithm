using System;

namespace VariationsWithRepsIteraive
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // k <= n
            int k = int.Parse(Console.ReadLine());
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
                    if (arr[i-1]<=n-1 || arr[0] >= n)
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

        private static void Print(int[] elements)
        {
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
