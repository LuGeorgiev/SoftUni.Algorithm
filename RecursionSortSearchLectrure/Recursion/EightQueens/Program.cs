using System;
using System.Collections.Generic;

namespace EightQueens
{
    class Program
    {
        private const int Size = 8;
        static int[,] board = new int[Size, Size];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void Solve(int row)
        {
            if (row == Size)
            {
                PrintSolution();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedFields(row, col);
                        Solve(row + 1);
                        UnmarkAttackedFields(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row,col]==1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void UnmarkAttackedFields(int row, int col)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static void MarkAttackedFields(int row, int col)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedCols.Contains(col) || attackedRows.Contains(row))
            {
                return false;
            }

            //left-up diagonal
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col - i;

                if (currentCol<0 || currentCol>=Size
                    || currentRow<0 || currentRow>=Size)
                {
                    break;
                }
                if (board[currentRow,currentCol]==1)
                {
                    return false;
                }
            }
            //right Up
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col + i;

                if (currentCol < 0 || currentCol >= Size
                    || currentRow < 0 || currentRow >= Size)
                {
                    break;
                }
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            //left-down
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col - i;

                if (currentCol < 0 || currentCol >= Size
                    || currentRow < 0 || currentRow >= Size)
                {
                    break;
                }
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }
            //right-down
            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col + i;

                if (currentCol < 0 || currentCol >= Size
                    || currentRow < 0 || currentRow >= Size)
                {
                    break;
                }
                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Solve(0);
        }
    }
}
