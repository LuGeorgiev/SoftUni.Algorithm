using System;
using System.Collections.Generic;

namespace AbaspaBasapa
{
    class Program
    {
        private static int[,] matrix;

        static void Main(string[] args)
        {
            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            matrix = new int[secondWord.Length + 1, firstWord.Length + 1];

            int highestValue = 0;
            int highestRow = 0;
            int highesCol = 0;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                var currentSymbol = secondWord[row - 1];
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    var symbolToCompare = firstWord[col - 1];

                    if (currentSymbol==symbolToCompare)
                    {
                        matrix[row, col] = matrix[row - 1, col - 1]++;
                    }

                    if (matrix[row,col]>highestValue || (matrix[row,col]==highestValue && col < highesCol))
                    {
                        highestValue = matrix[row, col];
                        highestRow = row;
                        highesCol = col;
                    }
                }
            }

            var result = new List<char>();
            while (true)
            {
                if (matrix[highestRow,highesCol]==0)
                {
                    break;
                }
                result.Add(secondWord[highestRow]);
                highestRow--;
                highesCol--;
            }
            result.Reverse();
            Console.WriteLine(string.Join("",result));
        }
    }
}
