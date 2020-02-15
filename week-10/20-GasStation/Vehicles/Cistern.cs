using System;
using _20_GasStation.Statics;

namespace _20_GasStation.Vehicles
{
    class Cistern : Truck
    {
        public Cistern(string model, string color, FuelReservoir.Type fuel)
            : base(model, color, fuel, Type.Cistern)
        { }

        public Cistern(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public Cistern(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public Cistern(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.Cistern), fuel)
        { }

        public Cistern()
            : this(RandomGen.FuelType())
        { }

        public void SupplyFuel(GasStation station, uint amount)
        {
            if (amount == 0)
            {
                Console.WriteLine($"{station.CompanyName} gas station has it's " +
                                  $"{FuelTank.FuelType.ToString().ToLower()} tank already full!");
            }
            else if (amount + station.FuelTanks[(int)FuelTank.FuelType].CurrentCapacity
                     > station.FuelTanks[(int)FuelTank.FuelType].MaxCapacity)
            {
                SupplyFuel(station, (uint)(station.FuelTanks[(int)FuelTank.FuelType].MaxCapacity
                           - station.FuelTanks[(int)FuelTank.FuelType].CurrentCapacity));
            }

            else
            {
                Console.WriteLine($"{station.CompanyName} gas station has bought from you {amount} units " +
                                  $"of {FuelTank.FuelType.ToString().ToLower()} for " +
                                  $"{amount * station.Prices[(int)FuelTank.FuelType] * 0.8 / Program.defaultUnit:0.00}" +
                                  $" credits!");
                FuelTank.CurrentCapacity -= (int)amount;
                station.RefillTank(FuelTank.FuelType, amount);
            }
        }

        public void SupplyFuel(GasStation station)
        {
            SupplyFuel(station, (uint)FuelReservoir.GetCapacity(GasStation.Size.Regular));
        }
    }
}
