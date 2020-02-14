using System;
using System.Collections.Generic;

namespace _20_GasStation
{
    class Vehicle
    {
        public enum Type { Car, SportsCar, SUV, Bike, Truck, Cistern }
        public enum Color { Black, DarkRed, Red, Yellow, SkyBlue, DarkBlue, Metallic, White }
        protected string VehicleType { get; }
        protected string VehicleModel { get; }
        protected string VehicleColor { get; }
        protected float FuelConsumption;
        FuelReservoir FuelTank;

        public Vehicle(Type vehicle, string model, string color, FuelReservoir.Type fuel)
        {
            FuelTank = new FuelReservoir(vehicle, fuel);
            VehicleType = vehicle.ToString();
            VehicleModel = model;
            VehicleColor = color;

            switch (vehicle)
            {
                case Type.SportsCar:
                    FuelConsumption = 1.5f * Program.defaultUnit;
                    break;
                case Type.SUV:
                    FuelConsumption = 1.3f * Program.defaultUnit;
                    break;
                case Type.Bike:
                    FuelConsumption = 1.2f * Program.defaultUnit;
                    break;
                default:
                    FuelConsumption = 1.0f * Program.defaultUnit;
                    break;
            }
        }

        public Vehicle(Type vehicle, string model, Color color, FuelReservoir.Type fuel)
            : this(vehicle, model, color.ToString(), fuel)
        { }
        
        public Vehicle(Type vehicle, string model, FuelReservoir.Type fuel)
            : this(vehicle, model, RandomGen.VehicleColor(), fuel)
        { }

        public Vehicle(Type vehicle, FuelReservoir.Type fuel)
            : this(vehicle, RandomGen.VehicleModel(vehicle), fuel)
        { }

        public Vehicle(Type vehicle)
            : this(vehicle, RandomGen.FuelType())
        { }

        public Vehicle(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleType(), fuel)
        { }

        public Vehicle()
            : this(RandomGen.VehicleType())
        { }

        public override string ToString()
        {
            return $"\nYou're now driving {VehicleColor.ToLower()} {VehicleModel}!\n" +
                   $"Vehicle type: {VehicleType} | Fuel type: {FuelTank.FuelType}\n" +
                   $"Fuel status: {FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity}";
        }
    }
    
    class Car : Vehicle
    {
        public Car(string model, string color, FuelReservoir.Type fuel, Type type = Type.Car)
            : base(type, model, color, fuel)
        {
            
        }

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

    class SportsCar : Car
    {
        public SportsCar(string model, string color, FuelReservoir.Type fuel)
            : base (model, color, fuel, Type.SportsCar)
        { }

        public SportsCar(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public SportsCar(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public SportsCar(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.SportsCar), fuel)
        { }

        public SportsCar()
            : this(RandomGen.FuelType())
        { }
    }

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
            : this(RandomGen.VehicleModel(Type.SportsCar), fuel)
        { }

        public SUV()
            : this(RandomGen.FuelType())
        { }
    }

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
    }

    class Bike : Vehicle
    {
        public Bike (string model, string color, FuelReservoir.Type fuel)
    : base(Type.Bike, model, color, fuel)
        { }

        public Bike(string model, Color color, FuelReservoir.Type fuel)
            : this(model, color.ToString(), fuel)
        { }


        public Bike(string model, FuelReservoir.Type fuel)
            : this(model, RandomGen.VehicleColor(), fuel)
        { }

        public Bike(FuelReservoir.Type fuel)
            : this(RandomGen.VehicleModel(Type.Car), fuel)
        { }

        public Bike()
            : this(RandomGen.FuelType())
        { }
    }
}
