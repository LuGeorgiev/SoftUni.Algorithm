using System;
using System.Collections.Generic;

namespace BinomialCoefficients
{
    class Program
    {
        private static Dictionary<string,int> coefficients =new Dictionary<string,int>();

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            coefficients.Add("0,0", 1);
            for (int i = 1; i <= row; i++)
            {
                coefficients[$"{i},0"] = coefficients[$"{i},{i}"] = 1;
            }

            int coefficient = CalculateCoef(row, col);

            Console.WriteLine(coefficient);
        }

        private static int CalculateCoef(int row, int col)
        {
            if (coefficients.ContainsKey($"{row},{col}"))
            {
                return coefficients[$"{row},{col}"];
            }

            var result = CalculateCoef(row - 1, col - 1) + CalculateCoef(row - 1, col);
            coefficients[$"{row},{col}"] = result;

            return result;
        }
    }
}
