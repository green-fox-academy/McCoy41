using System;

namespace _20_GasStation
{
    public enum FuelType { Gasoline, Diesel, Ethanol, LPG, Hydrogen }
    internal class FuelReservoir
    {
        public FuelType FuelType;
        public int MaxCapacity;
        public int CurrentCapacity;

        public FuelReservoir(FuelType fuel, int capacity, int init)
        {
            FuelType = fuel;
            MaxCapacity = capacity;
            CurrentCapacity = init;
        }

        public FuelReservoir(FuelType fuel, int capacity)
            : this(fuel, capacity, 0)
        { }

        public FuelReservoir(FuelType fuel, VehicleType vehicle)
            : this(fuel, GetCapacity(vehicle))
        { }

        public FuelReservoir(FuelType fuel, StationSize size)
            : this(fuel, GetCapacity(size), GetCapacity(size))
        { }

        static int GetCapacity(VehicleType vehicle)
        {
            switch (vehicle)
            {
                case VehicleType.Bike:
                    return 8 * Program.defaultUnit;
                case VehicleType.SUV:
                    return 15 * Program.defaultUnit;
                case VehicleType.Truck:
                    return 25 * Program.defaultUnit;
                case VehicleType.Cistern:
                    return GetCapacity(StationSize.Regular) + GetCapacity(VehicleType.Truck);
                default:
                    return 10 * Program.defaultUnit;
            }
        }

        static int GetCapacity(StationSize size)
        {
            switch (size)
            {
                case StationSize.Small:
                    return 100 * Program.defaultUnit;
                case StationSize.Large:
                    return 400 * Program.defaultUnit;
                case StationSize.Central:
                    return 800 * Program.defaultUnit;
                default:
                    return 250 * Program.defaultUnit;
            }
        }
    }
}
