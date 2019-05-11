using System;
using System.Linq;

namespace SumTo13
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();
            var numA = numbers[0];
            var numB = numbers[1];
            var numC = numbers[2];

            if (numA+numB+numC==13)
            {
                Console.WriteLine("Yes");
            }
            else if(numA + numB - numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (numA - numB + numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (numA - numB - numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (- numA + numB + numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (- numA + numB - numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (- numA - numB + numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (- numA - numB - numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (numA + numB + numC == 13)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }    
    }
}
