using System;
using System.Collections.Generic;

namespace ShortestPathLectureerWay
{
    class Program
    {
        private static List<int> indeces = new List<int>();
        private static char[] directions = new[] {'L','R','S' };
        private static List<string> maps = new List<string>();

        static void Main(string[] args)
        {
            var map = Console.ReadLine().ToCharArray();
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i]=='*')
                {
                    indeces.Add(i);
                }
            }

            FindMap(map, 0);
            Console.WriteLine(maps.Count);
            Console.WriteLine(string.Join(Environment.NewLine, maps));
        }

        private static void FindMap(char[] map, int currentIndex)
        {
            if (currentIndex==indeces.Count)
            {
                maps.Add(string.Join("", map));
                return;
            }

            foreach (var direction in directions)
            {
                map[indeces[currentIndex]] = direction;
                FindMap(map, currentIndex + 1);
            }
        }
    }
}
