using System;
using System.Collections.Generic;
using System.Text;

namespace _20_GasStation.Vehicles
{
    class Bike : SportsCar
    {
        public Bike(string model, string color, FuelReservoir.Type fuel)
            : base(model, color, fuel, Type.Bike)
        { }

        public Bike(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public Bike(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public Bike(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.Bike), fuel)
        { }

        public Bike()
            : this(RandomGen.FuelType())
        { }

        public override void Race(float modifier = 2.0f)
        {
            base.Race(modifier);
        }
    }
}
