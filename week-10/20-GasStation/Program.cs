using System;
using _20_GasStation.Vehicles;
using _20_GasStation.Statics;

namespace _20_GasStation
{
    
    class Program
    {
        public const int defaultUnit = 10;

        static void Main(string[] args)
        {
            /*
            GasStation station1 = new GasStation(GasStation.Size.Large,"McGass");
            station1.EmptyTank(FuelReservoir.Type.Gasoline, 200);
            station1.EmptyTank(FuelReservoir.Type.Diesel, 250);
            station1.EmptyTank(FuelReservoir.Type.Ethanol, 50);
            station1.EmptyTank(FuelReservoir.Type.LPG, 650);
            station1.EmptyTank(FuelReservoir.Type.Hydrogen, 5000);
            Console.WriteLine(station1.ToString());

            for (int i = 0; i < 10; i++)
            {
                Vehicle vehicle = new Vehicle();
                Console.WriteLine(vehicle.ToString());
            }

            Bike vehicle1 = new Bike();
            Console.WriteLine(vehicle1.ToString());
            vehicle1.Race();
            vehicle1.Horn();
            vehicle1.Refuel(station1,25);
            vehicle1.Race();
            vehicle1.Race();
            vehicle1.Drive();

            Cistern vehicle2 = new Cistern(FuelReservoir.Type.Hydrogen);
            vehicle2.Horn();
            vehicle2.SupplyFuel(station1);
            Console.WriteLine(vehicle2.ToString());
            */

            Console.WriteLine("Welcome to GasStation excersise!");

            GasStation station = new GasStation(GetInfo.StationSize(), GetInfo.StationName());

            Console.WriteLine(station.ToString());


        }

        static GasStation NewGasStation(GasStation.Size size, string name)
        {
            return new GasStation(size, name);
        }

    }
}
