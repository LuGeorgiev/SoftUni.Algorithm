using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsTourWarnsdorff
{
    class Position 
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

    }

    class Program
    {
        private static int[,] board;
        private static int [] possibleRows = new int[]{-2, -2, -1, 1, 2, 2, 1, -1};
        private static int [] possibleCols = new int[]{-1, 1, 2, 2, 1, -1, -2, -2};

        static void Main(string[] args)
        {
            var boardDimentions = int.Parse(Console.ReadLine());
            board = new int[boardDimentions, boardDimentions];

            MoveKnight(0, 0, 1);

        }

        private static void MoveKnight(int row, int col, int step)
        {
            int boardSize = board.GetLength(0);
            board[row, col] = step;

            if (step == boardSize * boardSize)
            {
                PrintMovement();
                return;
            }

            Position pos = FillPossiblePositions(row,col);

           
                MoveKnight(pos.Row, pos.Col, step + 1);
            

            board[row, col] = 0;
        }

        private static Position FillPossiblePositions(int row, int col)
        {
            var positions = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                int possibleRow = row - possibleRows[i];
                int possibleCol = col - possibleCols[i];

                if (possibleRow>=0 && possibleRow <board.GetLength(0)
                    && possibleCol>=0 && possibleCol < board.GetLength(0)
                    && board[possibleRow,possibleCol]==0)
                {
                    positions.Add(new Position(possibleRow, possibleCol));                    
                }
            }

            positions = positions
                .OrderBy(p => PossiblePositions(p))
                .ToList();

            return positions.First();
        }

        private static int PossiblePositions(Position current)
        {
            var positions = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                int possibleRow = current.Row - possibleRows[i];
                int possibleCol = current.Col - possibleCols[i];

                if (possibleRow >= 0 && possibleRow < board.GetLength(0)
                    && possibleCol >= 0 && possibleCol < board.GetLength(0)
                    && board[possibleRow, possibleCol] == 0)
                {
                    positions.Add(new Position(possibleRow, possibleCol));
                }
            }

            return positions.Count;
        }

        private static void PrintMovement()
        {
            int boardSize = board.GetLength(0);
            int size = (boardSize * boardSize).ToString().Length + 1;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write((board[i, j] + " ").PadLeft(size));
                }
                Console.WriteLine();
            }
        }
    }
}
