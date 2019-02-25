using System;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Draw(lines);
        }

        private static void Draw(int lines)
        {
            if (lines<=0)
            {
                return;
            }

            Console.WriteLine(new string('*',lines));
            Draw(lines - 1);
            Console.WriteLine(new string('#',lines));
        }
    }
}
