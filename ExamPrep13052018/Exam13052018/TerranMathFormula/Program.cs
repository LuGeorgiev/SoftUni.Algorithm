using System;
using System.Collections.Generic;
using System.Numerics;

namespace TerranMathFormula
{
    class Program
    {
        private static Dictionary<int, BigInteger> factorials = new Dictionary<int, BigInteger>();
        private static Dictionary<char,int> elementsCount = new Dictionary<char, int>();

        static void Main(string[] args)
        {

            var input = Console.ReadLine().ToCharArray();
            foreach (var symbol in input)
            {
                if (!elementsCount.ContainsKey(symbol))
                {
                    elementsCount.Add(symbol, 0);
                }
                elementsCount[symbol]++;
            }
            factorials.Add(1, 1);
            factorials.Add(2, 2);
            factorials.Add(3, 6);

            BigInteger head = Factorial(input.Length);
            foreach (var devider in elementsCount.Values)
            {
                head = head / Factorial(devider);
            }
            Console.WriteLine(head);
        }

        private static BigInteger Factorial(int member)
        {
            if (factorials.ContainsKey(member))
            {
                return factorials[member];
            }

            return member * Factorial(member - 1);
        }
    }
}
