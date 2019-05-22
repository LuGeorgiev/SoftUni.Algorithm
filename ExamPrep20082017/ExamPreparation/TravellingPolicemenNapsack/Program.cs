using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellingPolicemenNapsack
{
    class Street
    {
        public Street(string name, int dmg, int count, int fuelNeeded)
        {
            this.Name = name;
            this.Damage = dmg;
            this.Count = count;
            this.Length = fuelNeeded;
        }

        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int Length { get; set; }
        public int Count { get; set; }

        public override string ToString()
            => this.Name;
    }


    class Program
    {
        private static StringBuilder builder = new StringBuilder();
        static void Main(string[] args)
        {
            int currentFuel = int.Parse(Console.ReadLine());
            string input = "";
            var allStreets = new List<Street>();

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(',').Select(x => x.Trim()).ToArray();
                var currentStreet = new Street(
                    tokens[0],
                    int.Parse(tokens[1]),
                    int.Parse(tokens[2]),
                    int.Parse(tokens[3]));
                if (currentStreet.Count * 10 - currentStreet.Damage >= 0)
                {
                    allStreets.Add(currentStreet);
                }
            }

            var streetResult = new List<Street>();
            streetResult = NapsackTask(allStreets, currentFuel);
            streetResult.Reverse();

            int count = 0;
            int dmg = 0;
            int left = currentFuel;
            foreach (var street in streetResult)
            {
                count += street.Count;
                dmg += street.Damage;
                left -=  street.Length;
                builder.Append(street.Name + " -> ");
            }
            var names = "";
            if (builder.Length>0)
            {
                 names = builder.ToString().Trim().Substring(0,builder.Length-4);
            }

            Console.WriteLine(names);
            Console.WriteLine($"Total pokemons caught -> {count}");
            Console.WriteLine($"Total car damage -> {dmg}");
            Console.WriteLine($"Fuel Left -> {left}");
        }

        private static List<Street> NapsackTask(List<Street> items, int fuel)
        {
            int[,] values = new int[items.Count + 1, fuel + 1];
            bool[,] isItemIncludde = new bool[items.Count + 1, fuel + 1];
            var itemsTaken = new List<Street>();

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                int row = itemIndex + 1;
                Street item = items[itemIndex];

                for (int col = 1; col < fuel; col++)
                {
                    int excludeValue = values[row - 1, col];
                    int includedValue = 0;

                    if (item.Length <= col)
                    {
                        includedValue = (item.Count * 10 - item.Damage) + values[row - 1, col - item.Length];
                    }

                    if (includedValue > excludeValue)
                    {
                        values[row, col] = includedValue;
                        isItemIncludde[row, col] = true;
                    }
                    else
                    {
                        values[row, col] = excludeValue;
                    }
                }
            }

            int tempCap = fuel;
            for (int i = items.Count; i > 0; i--)
            {
                if (!isItemIncludde[i, tempCap])
                {
                    continue;
                }

                var current = items[i - 1];
                itemsTaken.Add(current);
                tempCap = tempCap - current.Length;
            }

            return itemsTaken;
        }
    }
}
