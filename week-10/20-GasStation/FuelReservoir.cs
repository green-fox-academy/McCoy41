using System;
using _20_GasStation.Vehicles;
using _20_GasStation.Statics;

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
            : this(fuel, GetInfo.TankCapacity(vehicle))
        { }
       
        public FuelReservoir(Vehicle.Type vehicle)
            : this(GetInfo.TankCapacity(vehicle))
        { }

        public FuelReservoir(GasStation.Size size, Type fuel)
            : this(fuel, GetInfo.TankCapacity(size), GetInfo.TankCapacity(size))
        { }
    }
}
