using System;

namespace _20_GasStation
{
    
    class Program
    {
        public const int defaultUnit = 10;

        static void Main(string[] args)
        {
            GasStation station1 = new GasStation(StationSize.Small,"NoName");
            Console.WriteLine(station1.ToString());
            station1.FuelTanks[(int)FuelType.Gasoline].CurrentCapacity = 800;
            station1.FuelTanks[(int)FuelType.Diesel].CurrentCapacity = 750;
            station1.FuelTanks[(int)FuelType.Ethanol].CurrentCapacity = 950;
            station1.FuelTanks[(int)FuelType.LPG].CurrentCapacity = 350;
            station1.FuelTanks[(int)FuelType.Hydrogen].CurrentCapacity = 0;
            Console.WriteLine(station1.ToString());
            station1.CompanyName = "YesName";
            Console.WriteLine(station1.ToString());
            station1.Prices[(int)FuelType.Gasoline] = 2.59f;
            station1.Prices[(int)FuelType.Diesel] = 2.42f;
            station1.Prices[(int)FuelType.Ethanol] = 1.38f;
            station1.Prices[(int)FuelType.LPG] = 1.09f;
            station1.Prices[(int)FuelType.Hydrogen] = 4.2f;
            Console.WriteLine(station1.ToString());


        }
    }
}
