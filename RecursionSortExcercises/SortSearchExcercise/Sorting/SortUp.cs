using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class SortUp
    {
        private static int[] InsertionSort(int[] toSort)
        {
            var sorted = new List<int>(toSort.Length);
            if (toSort.Length == 0)
            {
                return sorted.ToArray();
            }
            sorted.Add(toSort[0]);
            for (int i = 1; i < toSort.Length; i++)
            {
                var valToSort = toSort[i];
                bool wasInserted = false;
                for (int j = 0; j < sorted.Count; j++)
                {
                    if (valToSort <= sorted[j])
                    {
                        sorted.Insert(j, valToSort);
                        wasInserted = true;
                        break;
                    }
                }
                if (!wasInserted)
                {
                    sorted.Add(valToSort);
                }
            }

            return sorted.ToArray();
        }

        private static void BubbleSort(int[] toSort)
        {
            for (int i = 0; i < toSort.Length; i++)
            {
                for (int j = 0; j < toSort.Length - i - 1; j++)
                {
                    if (toSort[j] > toSort[j + 1])
                    {
                        SwapValues(toSort, j, j + 1);
                    }
                }
            }
        }

        private static void ShellSort(int[] toSort)
        {
            for (int i = 0; i < toSort.Length; i++)
            {
                int minValue = toSort[i];
                int minIndex = i;
                for (int j = i; j < toSort.Length; j++)
                {
                    if (toSort[j] < minValue)
                    {
                        minValue = toSort[j];
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    SwapValues(toSort, i, minIndex);
                }
            }
        }

        private static void SwapValues(int[] toSort, int firstIndex, int secondIndex)
        {
            var temp = toSort[secondIndex];
            toSort[secondIndex] = toSort[firstIndex];
            toSort[firstIndex] = temp;
        }

        private static int[] MergeSort(int[] toSort)
        {
            if (toSort.Length == 1)
            {
                return toSort;
            }
            var leftList = new List<int>();
            var rightList = new List<int>();
            int midIndex = toSort.Length / 2;
            for (int i = 0; i < midIndex; i++)
            {
                leftList.Add(toSort[i]);
            }
            for (int i = midIndex; i < toSort.Length; i++)
            {
                rightList.Add(toSort[i]);
            }
            leftList = MergeSort(leftList.ToArray()).ToList();
            rightList = MergeSort(rightList.ToArray()).ToList();

            var result = new List<int>();
            result = ConcatMerged(leftList, rightList);

            return result.ToArray();
        }

        private static List<int> ConcatMerged(List<int> leftList, List<int> rightList)
        {
            var result = new List<int>(leftList.Count + rightList.Count);

            while (leftList.Count != 0 && rightList.Count != 0)
            {
                if (leftList[0] < rightList[0])
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }
            while (leftList.Count != 0)
            {
                result.Add(leftList[0]);
                leftList.RemoveAt(0);
            }
            while (rightList.Count != 0)
            {
                result.Add(rightList[0]);
                rightList.RemoveAt(0);
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 4, 2, -1, 0 };

            //var sortedInts = InsertionSort(numbers);
            var sortedInts = MergeSort(numbers);
            Console.WriteLine(string.Join(" ", sortedInts));



            //BubbleSort(numbers);
            //ShellSort(numbers);

            //Console.WriteLine(string.Join(" ", numbers));
        }

    }
}
