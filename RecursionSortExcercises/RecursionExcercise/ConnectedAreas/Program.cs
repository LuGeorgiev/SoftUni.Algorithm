using System;
using System.Collections.Generic;

namespace ConnectedAreas
{
    class Program
    {
        class Position
        {
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { get; set; }

            public int Col { get; set; }
        }

        class Matrix : IComparable
        {
            public Matrix(int size, Position start)
            {
                this.Size = size;
                this.Start = start;
            }
            public int Size { get; set; }
            public Position Start { get; set; }

            public int CompareTo(object obj)
            {
                var item = (Matrix)obj;

                int compare = item.Size.CompareTo(this.Size);
                if (compare==0)
                {
                    compare = this.Start.Row.CompareTo(item.Start.Row);
                    if (compare==0)
                    {
                        compare = this.Start.Col.CompareTo(item.Start.Col);
                    }
                }

                return compare;
            }
        }

        private static char[,] matrix = new char[,]
        {
            {'*',' ',' ','*',' ',' ',' ','*',' ',' '},
            {'*',' ',' ','*',' ',' ',' ','*',' ',' '},
            {'*',' ',' ','*','*','*','*','*',' ',' '},
            {'*',' ',' ','*',' ',' ',' ','*',' ',' '},
            {'*',' ',' ','*',' ',' ',' ','*',' ',' '}
        };

        static SortedSet<Matrix> areas = new SortedSet<Matrix>();

        static void Main(string[] args)
        {
            FindAreas(matrix);
        }

        private static void FindAreas(char[,] matrix)
        {
            Position position = FindAreaStart(matrix);
            if (position.Col==-1 || position.Row==1)
            {
                PrintResult();
                return;
            }
            int size = 0;
            size = FindAreaSize(matrix, position,size);
            areas.Add(new Matrix(size, position));

            FindAreas(matrix);
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");
            int counter = 0;
            foreach (var area in areas)
            {
                counter++;
                Console.WriteLine($"Area #{counter} at ({area.Start.Row}, {area.Start.Col}), size: {area.Size}");
            }
        }

        private static int FindAreaSize(char[,] matrix, Position position, int size)
        {
            size++;
            int row = position.Row;
            int col = position.Col;
            matrix[row, col] = 'v';

            if (row < matrix.GetLength(0)-1 && matrix[row+1,col]==' ')
            {
                var downPosition = new Position(row + 1, col);
                size = FindAreaSize(matrix, downPosition, size);
            }
            if (row >= 1 && matrix[row - 1, col] == ' ')
            {
                var upPosition = new Position(row - 1, col);
                size = FindAreaSize(matrix, upPosition, size);
            }
            if (col < matrix.GetLength(1) - 1 && matrix[row, col+1] == ' ')
            {
                var rightPosition = new Position(row , col + 1);
                size = FindAreaSize(matrix, rightPosition, size);
            }
            if (col >= 1 && matrix[row, col - 1] == ' ')
            {
                var leftPosition = new Position(row, col - 1);
                size = FindAreaSize(matrix, leftPosition, size);
            }
            return size;
        }

        private static Position FindAreaStart(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]==' ')
                    {
                        return new Position(row, col);
                    }
                }
            }
            return new Position(-1, -1);
        }
    }
}
