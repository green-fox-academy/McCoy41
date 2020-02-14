using System;

namespace _20_GasStation
{
    internal class FuelReservoir
    {
        public enum Type { Gasoline, Diesel, Ethanol, LPG, Hydrogen }
        public Type FuelType { get; }
        public int MaxCapacity { get; }
        public int CurrentCapacity;

        public FuelReservoir(Type fuel, int capacity, int init)
        {
            FuelType = fuel;
            MaxCapacity = capacity;
            CurrentCapacity = init;
        }

        public FuelReservoir(Type fuel, int capacity)
            : this(fuel, capacity, 0)
        { }

        public FuelReservoir(int capacity)
            :this(RandomGen.FuelType(), capacity, 0)
        { }

        public FuelReservoir(Vehicle.Type vehicle, Type fuel)
            : this(fuel, GetCapacity(vehicle))
        { }
       
        public FuelReservoir(Vehicle.Type vehicle)
            : this(GetCapacity(vehicle))
        { }

        public FuelReservoir(GasStation.Size size, Type fuel)
            : this(fuel, GetCapacity(size), GetCapacity(size))
        { }

        static int GetCapacity(Vehicle.Type vehicle)
        {
            switch (vehicle)
            {
                case Vehicle.Type.Bike:
                    return 8 * Program.defaultUnit;
                case Vehicle.Type.SUV:
                    return 15 * Program.defaultUnit;
                case Vehicle.Type.Truck:
                    return 25 * Program.defaultUnit;
                case Vehicle.Type.Cistern:
                    return GetCapacity(GasStation.Size.Regular) + GetCapacity(Vehicle.Type.Truck);
                default:
                    return 10 * Program.defaultUnit;
            }
        }

        static int GetCapacity(GasStation.Size size)
        {
            switch (size)
            {
                case GasStation.Size.Small:
                    return 100 * Program.defaultUnit;
                case GasStation.Size.Large:
                    return 400 * Program.defaultUnit;
                case GasStation.Size.Central:
                    return 800 * Program.defaultUnit;
                default:
                    return 250 * Program.defaultUnit;
            }
        }
    }
}
