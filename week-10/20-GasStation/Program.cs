using System;

namespace _20_GasStation
{
    
    class Program
    {
        public const int defaultUnit = 10;

        static void Main(string[] args)
        {
            GasStation station1 = new GasStation(GasStation.Size.Small,"McGass");
            station1.EmptyTank(FuelReservoir.Type.Gasoline, 200);
            station1.EmptyTank(FuelReservoir.Type.Diesel, 250);
            station1.EmptyTank(FuelReservoir.Type.Ethanol, 50);
            station1.EmptyTank(FuelReservoir.Type.LPG, 650);
            station1.EmptyTank(FuelReservoir.Type.Hydrogen, 1000);
            Console.WriteLine(station1.ToString());

            for (int i = 0; i < 10; i++)
            {
                Vehicle vehicle = new Vehicle();
                Console.WriteLine(vehicle.ToString());
            }

        }

    }
}
