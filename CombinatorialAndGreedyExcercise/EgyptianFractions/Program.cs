using System;
using System.Collections.Generic;
using System.Linq;

namespace EgyptianFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split('/');
            var numerator = long.Parse(number[0]);//43 || a
            var denumerator = long.Parse(number[1]);//48 || b
            if (denumerator<numerator)
            {
                Console.WriteLine("Error...");
            }
            Console.WriteLine($"{numerator}/{ denumerator}=");

            var index = 2;// 3/7 -1/2
            var result = new List<int>();

            while (numerator!=0)
            {
                // 1/c
                var nextNumerator = numerator * index; // a * c (43 *2)
                var indexNumerator = denumerator; // b (48)

                var remaining = nextNumerator - indexNumerator; // a * c - b (86 - 48)
                if (remaining < 0)
                {
                    index++;
                    continue;
                }
                result.Add(index);
                numerator = remaining;
                denumerator = denumerator * index;

                index++;
            }
            Console.WriteLine(string.Join(" + ", result.Select(r=>$"1/{r}")));
        }
    }
}
