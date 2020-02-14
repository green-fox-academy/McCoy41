using System;

namespace _20_GasStation
{
    
    class Program
    {
        public const int defaultUnit = 10;

        static void Main(string[] args)
        {
            GasStation station1 = new GasStation(StationSize.Small);
            Console.WriteLine(station1.ToString());
            station1.EmptyTank(FuelType.Gasoline, 200);
            station1.EmptyTank(FuelType.Diesel, 250);
            station1.EmptyTank(FuelType.Ethanol, 50);
            station1.EmptyTank(FuelType.LPG, 650);
            station1.EmptyTank(FuelType.Hydrogen, 1200);
            Console.WriteLine(station1.ToString());
            station1.CompanyName = "McGas";
            station1.RefillTank(200);
            Console.WriteLine(station1.ToString());
            station1.PriceUpdate(FuelType.Gasoline, 2.59f);
            station1.PriceUpdate(FuelType.Diesel, 0.23f, true);
            station1.PriceUpdate(FuelType.Ethanol, 0.5f, false);
            station1.PriceUpdate(FuelType.LPG);
            station1.PriceUpdate(FuelType.Hydrogen, 12.6f);
            Console.WriteLine(station1.ToString());

            station1.PriceUpdate();
            Console.WriteLine(station1.ToString());
            station1.PriceUpdate(1.2f, true);
            Console.WriteLine(station1.ToString());
            station1.PriceUpdate(false);
            Console.WriteLine(station1.ToString());

        }
    }
}
