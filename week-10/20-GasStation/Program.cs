using System;

namespace _20_GasStation
{
    
    class Program
    {
        public const int defaultUnit = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GasStation station1 = new GasStation();
            GasStation station2 = new GasStation(StationSize.Small);
            GasStation station3 = new GasStation(StationSize.Regular);
            GasStation station4 = new GasStation(StationSize.Large);
            GasStation station5 = new GasStation(StationSize.Central);

            GasStation.PrintStatus(station1.FuelTanks, station1.Prices, station1.CompanyName);
            GasStation.PrintStatus(station2.FuelTanks, station2.Prices, station2.CompanyName);
            GasStation.PrintStatus(station3.FuelTanks, station3.Prices, station3.CompanyName);
            GasStation.PrintStatus(station4.FuelTanks, station4.Prices, station4.CompanyName);
            GasStation.PrintStatus(station5.FuelTanks, station5.Prices, station5.CompanyName);
            GasStation.PrintStatus(station4.FuelTanks, station4.Prices, station4.CompanyName);
        }
    }
}
