using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestZigZagSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var dp = new int[numbers.Length, 2];
            var prev = new int[numbers.Length, 2];

            dp[0, 0] = dp[0, 1] = 1;
            prev[0, 0] = prev[0, 1] = -1;
            var maxResult = 0;
            var maxindexRow = 0;
            var maxIndexCol = 0;

            for (int currentIndex = 1; currentIndex < numbers.Length; currentIndex++)
            {
                for (int previousIndex = 0; previousIndex < currentIndex; previousIndex++)
                {
                    var currentNuumber = numbers[currentIndex];
                    var previousNumber = numbers[previousIndex];

                    if (currentNuumber > previousNumber && 
                        dp[currentIndex,0] < dp[previousIndex,1]+1)
                    {
                        dp[currentIndex, 0] = dp[previousIndex, 1] + 1;
                        prev[currentIndex, 0] = previousIndex;

                    }

                    if (currentNuumber<previousNumber && 
                        dp[currentIndex,1]<dp[previousIndex,0]+1)
                    {
                        dp[currentIndex, 1] = dp[previousIndex, 0] + 1;
                        prev[currentIndex, 1] = previousIndex;
                    }    
                }

                if (dp[currentIndex, 0] > maxResult)
                {
                    maxResult = dp[currentIndex, 0];
                    maxindexRow = currentIndex;
                    maxIndexCol = 0;
                }
                if (dp[currentIndex, 1] > maxResult)
                {
                    maxResult = dp[currentIndex, 1];
                    maxindexRow = currentIndex;
                    maxIndexCol = 1;
                }
            }

            var result = new List<int>();
            while (maxindexRow>=0)
            {
                result.Add(numbers[maxindexRow]);
                maxindexRow = prev[maxindexRow, maxIndexCol];
                if (maxIndexCol==1)
                {
                    maxIndexCol = 0;
                }
                else
                {
                    maxIndexCol = 1;
                }
                result.Reverse();
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
