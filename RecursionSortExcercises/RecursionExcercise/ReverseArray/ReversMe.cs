using System;
using System.Linq;

namespace ReverseArray
{
    class ReversMe
    {
        static void ReverseArray<T>(T[] arr, int startIndex, int endIndex)
        {
            if (endIndex<=startIndex)
            {
                return;
            }
            T temp = arr[endIndex];
            arr[endIndex] = arr[startIndex];
            arr[startIndex] = temp;

            ReverseArray(arr, startIndex + 1, endIndex-1);
        }

        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            ReverseArray<int>(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
