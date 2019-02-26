using System;
using System.Collections.Generic;

namespace MergeSort
{
    public static class Mergesort<T> 
        where T: IComparable<T>
    {        

        public static T[] Merge(T[] arr)
        {
            var result = new T[arr.Length];
            var left = new T[arr.Length/2];
            var right = new T[arr.Length-arr.Length/2];

            if (arr.Length<=1)
            {
                return arr;
            }

            var middle = arr.Length / 2;
            for (int i = 0; i < middle; i++)
            {
                left[i]=arr[i];
            }
            for (int i = middle; i < arr.Length; i++)
            {
                right[i-middle]=arr[i];
            }
            left = Merge(left);
            right = Merge(right);

            if (left[left.Length-1].CompareTo(right[0])==-1
                || left[left.Length - 1].CompareTo(right[0]) == 0)
            {
                return Append(left, right);
            }

            result = Sort(left, right);

            return result;
        }

        private static T[] Sort(T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            var result = new List<T>();

            while (leftIndex<left.Length && rightIndex<right.Length)
            {
                if (left[leftIndex].CompareTo(right[rightIndex])==-1)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Length)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }
            while (rightIndex < right.Length)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result.ToArray();
        }

        private static T[] Append(T[] left, T[] right)
        {
            var result = new List<T>(left);
            foreach (var item in right)
            {
                result.Add(item);
            }

            return result.ToArray();
        }
      
    }
}
