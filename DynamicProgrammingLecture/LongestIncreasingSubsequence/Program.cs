using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //int[] input = new [] { 1, 2, 3, 5,4 };

            int[] longesSubsequence = CalculateLongest(input);
            Console.WriteLine(string.Join(" ", longesSubsequence));
        }

        private static int[] CalculateLongest(int[] input)
        {
            int[] lengths = new int[input.Length];
            int[] prevIndex = new int[input.Length];
            lengths[0] = 1;
            prevIndex[0] = -1;

            for (int i = 1; i < input.Length; i++)
            {
                var current = input[i];
                var currentMaxSequence = 1;
                var currentMaxIndex = -1;

                for (int j = i-1; j >=0; j--)
                {
                    if (current > input[j]
                        && currentMaxSequence <= lengths[j]+1)
                    {
                        currentMaxSequence = lengths[j] + 1;
                        currentMaxIndex = j;
                    }
                }

                lengths[i] = currentMaxSequence;
                prevIndex[i] = currentMaxIndex;
            }

            int longestSubLastIndex = 0;
            int maxValueOfLongest = int.MinValue;
            for (int i = 0; i < lengths.Length; i++)
            {
                if (lengths[i]>maxValueOfLongest)
                {
                    maxValueOfLongest = lengths[i];
                    longestSubLastIndex = i;
                }
            }
            var result = new List<int>();
            while (longestSubLastIndex>=0)
            {
                result.Add(input[longestSubLastIndex]);
                longestSubLastIndex = prevIndex[longestSubLastIndex];
            }
            result.Reverse();

            return result.ToArray();
        }
    }
}
