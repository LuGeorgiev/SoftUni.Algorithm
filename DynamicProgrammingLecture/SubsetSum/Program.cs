using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{       
    class Program
    {
        static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int>();
            result.Add(0, 0);
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                //calculate each new sums
                foreach (var number in result.Keys.ToList())
                {
                    var newSum = number + currentNumber;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            //Find all combinations without repetitions in order to reach the target
            var nums = new[] { 3, 5, 1, 4, 2 };

            var sums = CalcSums(nums);

            var target = 9;

            if (sums.ContainsKey(target))
            {
                Console.WriteLine("Yes");
                //retrive numbers that was used to reach the sum
                while (target!=0)
                {
                    var number = sums[target];
                    Console.WriteLine(number);

                    target -= number;

                }
            }
            else
            {
                Console.WriteLine("No");
            }

            //extract 
        }
    }
}
