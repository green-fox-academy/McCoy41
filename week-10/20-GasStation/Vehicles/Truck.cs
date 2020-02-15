using System;
using _20_GasStation.Statics;

namespace _20_GasStation.Vehicles
{
    class Truck : Vehicle
    {
        public Truck(string model, string color, FuelReservoir.Type fuel, Type type = Type.Truck)
            : base(type, model, color, fuel)
        { }

        public Truck(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public Truck(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public Truck(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.Truck), fuel)
        { }

        public Truck()
            : this(RandomGen.FuelType())
        { }
    }
}
