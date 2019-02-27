using System;

namespace MergeSortKenov
{
    class Program
    {
        static void Sort(int[] arrToSort, int startIndex, int endIndex)
        {
            if (startIndex>=endIndex) //one element
            {
                return;
            }

            var middleIndex = (startIndex + endIndex) / 2;
            //Recursion
            Sort(arrToSort, startIndex, middleIndex);
            Sort(arrToSort, middleIndex + 1, endIndex);

            Merge(arrToSort, startIndex, middleIndex, endIndex);
        }

        private static void Merge(int[] arrToSort, int startIndex, int middleIndex, int endIndex)
        {
            //arr already sorted
            if ( middleIndex < 0 || middleIndex+1 >=arrToSort.Length 
                || arrToSort[middleIndex]<=arrToSort[middleIndex+1])
            {
                return;
            }

            int[] helpArr = new int[arrToSort.Length];
            for (int i = startIndex; i <=endIndex; i++)
            {
                helpArr[i] = arrToSort[i];
            }

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    arrToSort[i] = helpArr[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    arrToSort[i] = helpArr[leftIndex++];
                }
                else if (helpArr[leftIndex]<=helpArr[rightIndex])
                {
                    arrToSort[i] = helpArr[leftIndex++];
                }
                else
                {
                    arrToSort[i] = helpArr[rightIndex++];

                }
            }

        }

        static void Main(string[] args)
        {
            var numbers = new[] { 4, 5, 7, 8, 1, 3, -213, 0 };
            Sort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
