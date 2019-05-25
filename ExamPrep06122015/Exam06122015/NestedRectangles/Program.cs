using System;
using System.Collections.Generic;
using System.Linq;

namespace NestedRectangles
{
    class Program
    {
        private static List<Rectangle> rectangles = new List<Rectangle>();

        static void Main(string[] args)
        {
            FillInRectangles();

            foreach (var rectangle in rectangles)
            {
                if (rectangle.MaxDepth ==0 )
                {
                    GetDepth(rectangle);
                }
            }
            var maxRectangle = rectangles.Max();
            var result = new List<Rectangle>();
            while (maxRectangle!=null)
            {
                result.Add(maxRectangle);
                maxRectangle = maxRectangle.Next;
            }
            Console.WriteLine(string.Join(" < ",result));
        }

        private static void GetDepth(Rectangle rectangle)
        {
            var innerRectangles = new List<Rectangle>();
            foreach (var current in rectangles)
            {
                if (current != rectangle && rectangle.IsNestetOf(current))
                {
                    if (current.MaxDepth==0)
                    {
                        GetDepth(current);
                    }

                    innerRectangles.Add(current);
                }
            }

            if (innerRectangles.Count==0)
            {
                rectangle.MaxDepth = 1;
            }
            else
            {
                var biggestSoFar = innerRectangles.Max();
                rectangle.MaxDepth = biggestSoFar.MaxDepth + 1;
                rectangle.Next = biggestSoFar;
            }
        }

        private static void FillInRectangles()
        {
            var input = "";
            while ((input=Console.ReadLine())!="End")
            {
                var rectArgs = input
                    .Split(' ')
                    .ToArray();
                var name = rectArgs[0].Substring(0, rectArgs[0].Length - 1);
                var left = int.Parse(rectArgs[1]);
                var top = int.Parse(rectArgs[2]);
                var right = int.Parse(rectArgs[3]);
                var bottom = int.Parse(rectArgs[4]);
                var rectangle = new Rectangle(name, left, top, right, bottom);

                rectangles.Add(rectangle);
            }
        }
    }

    internal class Rectangle : IComparable<Rectangle>
    {
        public Rectangle(string name, int left, int top, int right, int bottom)
        {
            this.Name = name;
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.MaxDepth = 0;
        }

        public string Name { get; private set; }
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Right { get; private set; }
        public int Bottom { get; private set; }
        public int MaxDepth { get; set; }
        public Rectangle Next { get; set; }

        public int CompareTo(Rectangle other)
        {
            int compare = this.MaxDepth.CompareTo(other.MaxDepth);

            if (compare==0)
            {
                compare = other.Name.CompareTo(this.Name);
            }

            return compare;
        }
        public override string ToString()
            => this.Name;

        public bool IsNestetOf(Rectangle other)
            => this.Left <= other.Left
                && this.Right >= other.Right
                && this.Top >= other.Top
                && this.Bottom <= other.Bottom;
    }
}
