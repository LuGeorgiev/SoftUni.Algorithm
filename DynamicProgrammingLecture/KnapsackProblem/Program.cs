using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    class Program
    {
        class Item
        {
            public int Weight { get; set; }

            public int Price { get; set; }

            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            //var items = new[]
            //{
            //    new Item {Weight=5,Price=30 ,Name="Item1"},
            //    new Item {Weight=8,Price=120,Name="Item2" },
            //    new Item {Weight=7,Price=10,Name="Item3" },
            //    new Item {Weight=0,Price=20,Name="Item4" },
            //    new Item {Weight=4,Price=50,Name="Item5" },
            //    new Item {Weight=5,Price=80,Name="Item6" },
            //    new Item {Weight=2,Price=10,Name="Item7" }
            //};
            //var knapsackCapacity = 20;

            int knapsackCapacity = int.Parse(Console.ReadLine());
            var items = new List<Item>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                var tokens = line.Split(' ');
                items.Add(new Item
                {
                    Name = tokens[0],
                    Weight =int.Parse(tokens[1]),
                    Price =int.Parse(tokens[2]),
                });
            }

            Item[] itemsTaken = FillWithItems(items.ToArray(), knapsackCapacity);

            Console.WriteLine($"Total weight: {itemsTaken.Sum(x => x.Weight)}");
            Console.WriteLine($"Total price: {itemsTaken.Sum(x => x.Price)}");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        private static Item[] FillWithItems(Item[] items, int capacity)
        {
            var maxPrice = new int[items.Length + 1, capacity + 1];
            var itemsIncluded = new bool[items.Length + 1, capacity + 1];

            for (int index = 1; index <= items.Length; index++)
            {
                var currentItem = items[index - 1];

                for (int curentCap = 0; curentCap <= capacity; curentCap++)
                {
                    if (currentItem.Weight > curentCap)
                    {
                        //copy previous best price
                        maxPrice[index, curentCap] = maxPrice[index - 1, curentCap];
                        continue;
                    }
                    //calculate best price of the item and currently best with the capacity that left after thi sitem was includde
                    int currentValuWithItem = currentItem.Price + maxPrice[index - 1, curentCap - currentItem.Weight];

                    //check if this ithem is worth taking
                    if (currentValuWithItem > maxPrice[index - 1, curentCap])
                    {
                        maxPrice[index, curentCap] = currentValuWithItem;
                        itemsIncluded[index, curentCap] = true;
                    }
                    else
                    {
                        maxPrice[index, curentCap] = maxPrice[index - 1, curentCap];
                    }
                }
            }

            var itemsTaken = new List<Item>();

            int capacityLeft = capacity;
            for (int item = items.Length; item > 0; item--)
            {
                for (int curCapacity = capacityLeft; curCapacity >=0; curCapacity--)
                {
                    if (itemsIncluded[item,curCapacity]==true)
                    {
                        itemsTaken.Add(items[item - 1]);
                        capacityLeft -= items[item - 1].Weight;
                        break;
                    }
                }
            }
            itemsTaken.Reverse();

            return itemsTaken.ToArray();
        }
    }
}
