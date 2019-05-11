using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingZones
{
    class Program
    {
        static int shopX;
        static int shopY;
        static int secondsPerSquare;
        static void Main(string[] args)
        {
            var numberOfParkingZones = int.Parse(Console.ReadLine());
            var parkingZones=FillZones(numberOfParkingZones);

            var parkingPlaces = Console.ReadLine()
                .Split(';')
                .Select(x=>x.Trim())
                .ToArray();

            var shopToken = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .Select(int.Parse)
                .ToArray();
            shopX = shopToken[0];
            shopY = shopToken[1];
            secondsPerSquare = int.Parse(Console.ReadLine());

            var parkingPlacesd = new SortedSet<ParkingPlace>();
            foreach (var parkSpot in parkingPlaces)
            {
                CalculateToll(parkingZones, parkSpot, parkingPlacesd);
            }
            var result = parkingPlacesd.First();

            Console.WriteLine($"Zone Type: {result.Zone.Name}; X: {result.X}; Y: {result.Y}; Price: {result.StayPrice:F2}");
        }

        private static void CalculateToll(IEnumerable<ParkingZone> parkingZones, string parkSpot, SortedSet<ParkingPlace> sortedParking)
        {
            var parkingTokens = parkSpot.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var parkX = int.Parse(parkingTokens[0]);
            var parkY = int.Parse(parkingTokens[1]);

            ParkingZone parkedZone = parkingZones.FirstOrDefault(x => x.IsInZone(parkX, parkY));

            var distance = Math.Abs(parkX - shopX) + Math.Abs(parkY - shopY)-1;
            var minutesToPay = (int)Math.Ceiling(distance * 2 * secondsPerSquare / 60m);
            var priceTotal = minutesToPay * parkedZone.Price;

            sortedParking.Add(new ParkingPlace(priceTotal, minutesToPay, parkedZone, parkX, parkY));            
        }
                

        private static IEnumerable<ParkingZone> FillZones(int numberOfParkingZones)
        {
            var parkingZones = new List<ParkingZone>();
            for (int i = 0; i < numberOfParkingZones; i++)
            {
                var zoneTokens = Console.ReadLine()
                    .Split(new[] { ' ', ',',':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                parkingZones.Add(new ParkingZone(zoneTokens[0],
                                       int.Parse(zoneTokens[1]),
                                       int.Parse(zoneTokens[2]),
                                       int.Parse(zoneTokens[3]),
                                       int.Parse(zoneTokens[4]),
                                       decimal.Parse(zoneTokens[5])));
            }

            return parkingZones;
        }
    }

    class ParkingZone
    {
        public ParkingZone(string name, int x, int y, int oxLen, int oyLen, decimal price)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.OxLen = oxLen;
            this.OyLen = oyLen;
            this.Price = price;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int OxLen { get; private set; }
        public int OyLen { get; private set; }
        public decimal Price { get; private set; }
        public string Name { get; private set; }

        public bool IsInZone(int x, int y)
            => this.X <= x && this.X + this.OxLen >= x
                && this.Y <= y && this.Y + this.OyLen >= y;
    }

    class ParkingPlace :IComparable<ParkingPlace>
    {
        public ParkingPlace(decimal stayPrice, int time, ParkingZone zone, int x, int y)
        {
            this.StayPrice = stayPrice;
            this.Time = time;
            this.Zone = zone;
            this.X = x;
            this.Y = y;
        }

        public decimal StayPrice { get; private set; }
        public int Time { get; private set; }
        public ParkingZone Zone { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public int CompareTo(ParkingPlace other)
        {
            int compare = this.StayPrice.CompareTo(other.StayPrice);
            if (compare==0)
            {
                compare = this.Time.CompareTo(other.Time);
            }

            return compare;
        }
    }
}
