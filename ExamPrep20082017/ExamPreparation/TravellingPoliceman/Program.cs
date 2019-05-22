using System;
using System.Collections.Generic;
using System.Linq;

namespace TravellingPoliceman
{
    class Street : IComparable<Street>
    {
        public Street(string name, int dmg, int pokemons, int fuelNeeded, int id)
        {
            this.Name = name;
            this.Length = fuelNeeded;
            this.Id = id;
            this.Pokemons = pokemons;
            this.Damage =  dmg;

        }

        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int Length { get; set; }
        public int Id { get; set; }
        public int Pokemons { get; set; }
        public int Rank 
            => this.Pokemons * 10 - this.Damage;

        public int CompareTo(Street other)
        {
            var compare = other.Rank.CompareTo(this.Rank);
            if (compare==0)
            {
                compare = this.Length.CompareTo(other.Length);
            }
            return compare;
        }
    }


    class Program
    {
        private static SortedSet<Street> allStreets = new SortedSet<Street>();
        private static SortedSet<Street> streetsToPass = new SortedSet<Street>(Comparer<Street>.Create((x,y)=>x.Id.CompareTo(y.Id)));

        static void Main(string[] args)
        {
            int currentFuel = int.Parse(Console.ReadLine());
            string input = "";
            int count = 0;

            while ((input = Console.ReadLine())!="End")
            {
                var tokens = input.Split(',').Select(x => x.Trim()).ToArray();
                var currentStreet = new Street(
                    tokens[0],
                    int.Parse(tokens[1]),
                    int.Parse(tokens[2]),
                    int.Parse(tokens[3]),
                    ++count);
                if (currentStreet.Rank >= 0)
                {
                    allStreets.Add(currentStreet);
                }
            }
            var totalPokemons = 0;
            var totalCarDamage = 0;

            foreach (var street in allStreets)
            {
                if (currentFuel==0)
                {
                    break;
                }
                else if (currentFuel - street.Length < 0)
                {
                    continue;
                }

                totalCarDamage += street.Damage;
                totalPokemons += street.Pokemons;
                currentFuel -= street.Length;

                streetsToPass.Add(street);
            }

            var streetNames = string.Join(" -> ", streetsToPass.Select(x => x.Name));
            Console.WriteLine(streetNames);
            Console.WriteLine($"Total pokemons caught -> {totalPokemons}");
            Console.WriteLine($"Total car damage -> {totalCarDamage}");
            Console.WriteLine($"Fuel Left -> {currentFuel}");
        }
    }
}
