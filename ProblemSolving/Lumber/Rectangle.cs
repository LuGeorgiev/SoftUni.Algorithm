using System;
using System.Collections.Generic;
using System.Text;

namespace Lumber
{
    public class Rectangle
    {
        public Rectangle()
        {

        }

        public Rectangle(int id, int ax, int ay, int bx, int by)
        {
            this.Id = id;
            this.Ax = ax;
            this.Ay = ay;
            this.Bx = bx;
            this.By = by;
        }

        public int Ax { get; private set; }
        public int Ay { get; private set; }
        public int Bx { get; private set; }
        public int By { get; private set; }
        public int Id { get; private set; }

        public bool AreRectanglesIntersected(Rectangle other)
        {
            bool isAIn = this.InPointInRectangle(other.Ax, other.Ay);
            bool isBIn = this.InPointInRectangle(other.Bx, other.Ay);
            bool isCIn = this.InPointInRectangle(other.Bx, other.By);
            bool isDIn = this.InPointInRectangle(other.Ax, other.By);

            return isAIn || isBIn || isCIn || isDIn;
        }

        private bool InPointInRectangle(int x, int y)
            => x >= this.Ax
            && x <= this.Bx
            && y <= this.Ay
            && y >= this.By;
    }
}
