using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRight
{
    //Given a matrix of N by M cells filled with positive integers, find the path from top left to bottom right with a highest sum of cells by moving only down or right.

    class Program
    {
        private static int[,] matrix;

        static void Main(string[] args)
        {
            FillMatrix();
            int[,] highesSums = CalculateSums();
            string path = ShowIndexPath(highesSums);
            Console.WriteLine(path);
        }

        private static string ShowIndexPath(int[,] highesSums)
        {
            int startRow = highesSums.GetLength(0) - 1;
            int startCol = highesSums.GetLength(1) - 1;
            var indexes = new List<string>();
            indexes.Add($"[{startRow}, {startCol}]");
            while (startRow >= 0 && startCol >= 0)
            {
                int upperSum = -1;
                if (startRow - 1 >= 0)
                {
                    upperSum = highesSums[startRow - 1, startCol];
                }
                int leftSum = -1;
                if (startCol - 1 >= 0)
                {
                    leftSum = highesSums[startRow, startCol - 1];
                }

                if (upperSum > leftSum)
                {
                    indexes.Add($"[{--startRow}, {startCol}]");
                }
                else
                {
                    indexes.Add($"[{startRow}, {--startCol}]");
                }
            }
            indexes.RemoveAt(indexes.Count - 1);


            indexes.Reverse();
            return string.Join(" ", indexes);
        }

        private static int[,] CalculateSums()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var resultMatrix = new int[rows, cols];
            resultMatrix[0, 0] = matrix[0, 0];

            //fill first row
            for (int i = 1; i < cols; i++)
            {
                resultMatrix[0, i] = resultMatrix[0, i - 1] + matrix[0, i];
            }

            //fill first coll
            for (int i = 1; i < rows; i++)
            {
                resultMatrix[i, 0] = resultMatrix[i - 1, 0] + matrix[i, 0];
            }

            //fill other cells
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    int leftSum = matrix[row, col] + resultMatrix[row, col - 1];
                    int upSum = matrix[row, col] + resultMatrix[row - 1, col];

                    resultMatrix[row, col] = Math.Max(leftSum, upSum);
                }
            }

            return resultMatrix;
        }

        private static void FillMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

        }
    }
}
