using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01ParticlesSelector
{
    class Program
    {
        private static Dictionary<int, BigInteger> factResults = new Dictionary<int, BigInteger>();

        static void Main(string[] args)
        {
            int nominator = int.Parse(Console.ReadLine());
            int dennominator = int.Parse(Console.ReadLine());
            factResults.Add(0, 1);
            factResults.Add(1, 1);
            factResults.Add(2, 2);

            Console.WriteLine(Factorial(nominator)/(Factorial(dennominator)*Factorial(nominator-dennominator)));
        }

        private static BigInteger Factorial(int step)
        {
            if (factResults.ContainsKey(step))
            {
                return factResults[step];
            }

            return factResults[step] = step * Factorial(step - 1);
        }
    }
}
