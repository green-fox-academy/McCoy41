using System;
using System.Collections.Generic;
using System.Text;

namespace _20_GasStation.Vehicles
{
    class Car : Vehicle
    {
        public Car(string model, string color, FuelReservoir.Type fuel, Type type = Type.Car)
            : base(type, model, color, fuel)
        { }

        public Car(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public Car(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public Car(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.Car), fuel)
        { }

        public Car()
            : this(RandomGen.FuelType())
        { }
    }
}
