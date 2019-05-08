using System;
using System.Collections.Generic;
using System.Linq;

namespace Elections
{
    //    You are given the results from the elections.There are N parties that have enough votes and are given seats in the parliament. You are given the seats for each one of the parties.For the parties to have majority in the parliament they need at least K seats (that means K or more seats). Parties can combine with each other in order to have K or more seats together.
    //Write a program to find the number of all possible combinations of parties with sum of seats K or more.

    //Problem Solve
    //Find number of combinations (1-N) without repetitions that satisfy цондитион 

    class Program
    {
        private static int[] elements;
        private static int combinationsCount;
        private static int minSeats;

        static void Main(string[] args)
        {
            combinationsCount = 0;
            minSeats = int.Parse(Console.ReadLine());
            var parties = int.Parse(Console.ReadLine());
            elements = new int[parties];
            for (int i = 0; i < parties; i++)
            {
                elements[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                foreach (var combo in Combinations(i, elements.Length))
                {
                    CalculatSeatSum(combo);
                }
            }

            Console.WriteLine(combinationsCount);
        }

        private static void CalculatSeatSum(int[] combo)
        {
            var sum = 0;

            for (int i = 0; i < combo.Length ; i++)
            {
                sum+=elements[combo[i]];
            }

            if (sum>=minSeats)
            {
                combinationsCount++;
            }
        }

        private static IEnumerable<int[]> Combinations(int k, int n)
        {
            var result = new int[k];
            var stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
