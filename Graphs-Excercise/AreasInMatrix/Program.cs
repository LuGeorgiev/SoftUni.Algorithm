using System;
using System.Collections.Generic;
using System.Linq;

namespace AreasInMatrix
{
//    We are given a matrix of letters of size N * M.Two cells are neighbor if they share a common wall.Write a program to find the connected areas of neighbor cells holding the same letter.Display the total number of areas and the number of areas for each alphabetical letter (ordered by alphabetical order). 
//On the first line is given the number of rows.

    class Program
    {
        static char[,] matrix;
        static bool[,] visited;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var firstLine = Console.ReadLine().Trim().ToCharArray();

            matrix = new char[rows, firstLine.Length];
            visited = new bool[rows, firstLine.Length];

            FillLineInMAtrix(firstLine, 0);
            for (int i = 1; i < rows; i++)
            {
                var nextLine = Console.ReadLine().Trim().ToCharArray();
                FillLineInMAtrix(nextLine, i);
            }

            var symbolsByZoneCount = new SortedDictionary<char, int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < firstLine.Length; j++)
                {
                    if (!visited[i,j])
                    {
                        var currentSymbol = matrix[i, j];
                        visited[i, j] = true;
                        if (!symbolsByZoneCount.ContainsKey(currentSymbol))
                        {
                            symbolsByZoneCount[currentSymbol] = 0;
                        }
                        symbolsByZoneCount[currentSymbol]++;
                        MarkVisitedCellDFS(i, j, currentSymbol);
                    }
                }
            }
            var areas = symbolsByZoneCount.Values.Sum(x => x);
            Console.WriteLine($"Areas: {areas}");
            foreach (var letter in symbolsByZoneCount.Keys)
            {
                Console.WriteLine($"Letter '{letter}' -> {symbolsByZoneCount[letter]}");
            }
        }

        private static void FillLineInMAtrix(char[] line, int row)
        {
            for (int i = 0; i < line.Length; i++)
            {
                matrix[row, i] = line[i];
            }
        }

        private static void MarkVisitedCellDFS(int row, int coll, char symbol)
        {
            

            //Move down
            if (CellIsInSameArea(row+1, coll,symbol))
            {
                visited[row + 1, coll] = true;
                MarkVisitedCellDFS(row + 1, coll, symbol);
            }

            //Move Up
            if (CellIsInSameArea(row - 1, coll, symbol))
            {
                visited[row - 1, coll] = true;
                MarkVisitedCellDFS(row - 1, coll, symbol);
            }

            //Move Left
            if (CellIsInSameArea(row, coll -1, symbol))
            {
                visited[row, coll-1] = true;
                MarkVisitedCellDFS(row, coll-1, symbol);
            }

            //Move right
            if (CellIsInSameArea(row , coll + 1 , symbol))
            {
                visited[row, coll+1] = true;
                MarkVisitedCellDFS(row , coll+1, symbol);
            }
        }

        private static bool CellIsInSameArea(int row, int coll, char symbol)
        {
            int rows = matrix.GetLength(0);
            int colls = matrix.GetLength(1);

            return row >= 0 
                && coll >= 0
                && row < rows 
                && coll < colls
                && visited[row, coll] == false
                && matrix[row, coll] == symbol;
        }
    }
}
