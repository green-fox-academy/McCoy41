using System;
using _20_GasStation.Statics;

namespace _20_GasStation.Vehicles
{
    class SUV : Car
    {
        public SUV(string model, string color, FuelReservoir.Type fuel)
            : base(model, color, fuel, Type.SUV)
        { }

        public SUV(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public SUV(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public SUV(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.SUV), fuel)
        { }

        public SUV()
            : this(RandomGen.FuelType())
        { }
    }
}
