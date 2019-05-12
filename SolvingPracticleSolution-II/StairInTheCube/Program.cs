using System;
using System.Collections.Generic;
using System.Linq;

namespace StairInTheCube
{
    class Program
    {
        static char[,,] matrix;
        static Dictionary<char, int> symbolsByCount= new Dictionary<char, int>();

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size, size];
            //Fill Matrix
            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine();
                FillRowInMatrix(currentLine, row);
            }
            if (size>=3)
            {
                for (int layer = 1; layer < size-1; layer++)
                {
                    for (int row = 1; row < size-1; row++)
                    {
                        for (int col = 1; col < size-1; col++)
                        {
                            var currentSymbol = matrix[layer, row, col];
                            if (matrix[layer - 1,row,col] == currentSymbol &&
                                matrix[layer + 1,row,col] ==currentSymbol &&
                                matrix[layer, row + 1, col] == currentSymbol &&
                                matrix[layer, row - 1, col] == currentSymbol &&
                                matrix[layer, row, col + 1] == currentSymbol &&
                                matrix[layer, row, col - 1] == currentSymbol )
                            {
                                if (!symbolsByCount.ContainsKey(currentSymbol))
                                {
                                    symbolsByCount.Add(currentSymbol, 0);
                                }
                                symbolsByCount[currentSymbol]++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(symbolsByCount.Values.Sum());
            foreach (var kvp in symbolsByCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        private static void FillRowInMatrix(string currentLine, int row)
        {
            var layers = currentLine.Split('|').ToArray();
            for (int layer = 0; layer < layers.Length; layer++)
            {
                var colls = layers[layer].Split(' ').Where(x=>x.Length>0).ToArray();
                for (int col = 0; col < colls.Length; col++)
                {
                    matrix[layer, row, col] = colls[col][0];
                }
            }
        }
    }
}
