using System;
using System.Collections.Generic;

namespace _20_GasStation
{
    class Vehicle
    {
        public enum Type { Car, SportsCar, SUV, Bike, Truck, Cistern }
        public enum Color { Black, Dark_Red, Red, Yellow, Sky_Blue, Dark_Blue, Metallic, White }
        protected string VehicleType { get; }
        protected string VehicleModel { get; }
        protected string VehicleColor { get; }
        protected float FuelConsumption;
        protected FuelReservoir FuelTank;

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
            if (vehicle == Type.Cistern) FuelTank.CurrentCapacity = FuelTank.MaxCapacity;
            else FuelTank.CurrentCapacity = 3 * (int)FuelConsumption;
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
            return $"\nYou're now driving {VehicleColor.ToLower().Replace("_"," ")} {VehicleModel}!\n" +
                   $"Vehicle type: {VehicleType} | Fuel type: {FuelTank.FuelType}\n" +
                   $"Fuel status: {FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity}";
        }

        public void Horn()
        {
            Console.WriteLine($"Your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} is now honking!");
        }

        public void Drive()
        {
            if (FuelTank.CurrentCapacity == 0)
            {
                Console.WriteLine($"Your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} majestically " +
                                  $"stands in the middle of the road... " +
                                  $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
            }
            else if (FuelConsumption > FuelTank.CurrentCapacity && FuelTank.CurrentCapacity > 0)
            {
                Console.WriteLine($"Your car has just run out of fuel. Thankfully, good people of the road " +
                                  $"helped to push your car to the closest gas station. (you would have " +
                                  $"{FuelTank.CurrentCapacity - (int)FuelConsumption}/{FuelTank.MaxCapacity})");
                FuelTank.CurrentCapacity = 0;
            }
            
            else
            {
                if (2 * FuelConsumption >= FuelTank.CurrentCapacity)
                {
                    Console.WriteLine($"You should visit the gas station, your fuel tank is running dry! " +
                                      $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
                }
                Console.WriteLine($"You are cruising the land like a boss in your {VehicleColor.ToLower()} " +
                                  $"{VehicleModel}! (-{(int)FuelConsumption} units of fuel)");
                FuelTank.CurrentCapacity -= (int)FuelConsumption;
            }
        }

        public void Refuel(GasStation station, uint amount)
        {
            if (amount + FuelTank.CurrentCapacity > FuelTank.MaxCapacity)
            {
                Refuel(station);
            }
            else if(amount > station.FuelTanks[(int)FuelTank.FuelType].CurrentCapacity)
            {
                Refuel(station, (uint)station.FuelTanks[(int)FuelTank.FuelType].CurrentCapacity);
            }
            else
            {
                Console.WriteLine($"You have bought {amount} units of {FuelTank.FuelType} for " +
                                  $"{amount*station.Prices[(int)FuelTank.FuelType]/ Program.defaultUnit:0.00} Cr.!");
                FuelTank.CurrentCapacity += (int)amount;
                Console.WriteLine($"(your tank is now at {FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
                station.EmptyTank(FuelTank.FuelType, amount);
            }
        }

        public void Refuel(GasStation station)
        {
            Refuel(station, (uint)(FuelTank.MaxCapacity - FuelTank.CurrentCapacity));
        }
    }
    
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

        public void Race()
        {
            if (FuelTank.CurrentCapacity == 0)
            {
                Console.WriteLine($"Your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} majestically " +
                                  $"stands in the middle of the road... " +
                                  $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
            }
            else if (2.5 * FuelConsumption > FuelTank.CurrentCapacity && FuelTank.CurrentCapacity > 0)
            {
                if(FuelConsumption < FuelTank.CurrentCapacity)
                {
                    Console.WriteLine($"You were too scared to race, as you were low on fuel " +
                                      $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity}), so instead you drove " +
                                      $"your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} to" +
                                      $"the closest gas station. (-{(int)FuelConsumption} units of fuel)");
                    FuelTank.CurrentCapacity -= (int)FuelConsumption;
                }
                else
                {
                    Console.WriteLine($"Your car has just run out of fuel. Thankfully, good people of the road " +
                                      $"helped to push your car to the closest gas station. (you would have " +
                                      $"{FuelTank.CurrentCapacity - (int)FuelConsumption}/{FuelTank.MaxCapacity})");
                    FuelTank.CurrentCapacity = 0;
                }
            }
            else
            {
                if (5 * FuelConsumption >= FuelTank.CurrentCapacity)
                {
                    Console.WriteLine($"You should visit the gas station, your fuel tank is running dry! " +
                                      $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
                }
                Console.WriteLine($"You are blazing through the land in your {VehicleColor.ToLower()} " +
                                  $"{VehicleModel}, aiming for new speed record! " +
                                  $"(-{(int)(2.5 * FuelConsumption)} units of fuel)");
                FuelTank.CurrentCapacity -= (int)(2.5 * FuelConsumption);
            }
        }
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
            : this(RandomGen.VehicleModel(Type.Bike), fuel)
        { }

        public Bike()
            : this(RandomGen.FuelType())
        { }

        public void Race()
        {
            if (FuelTank.CurrentCapacity == 0)
            {
                Console.WriteLine($"Your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} majestically " +
                                  $"stands in the middle of the road... " +
                                  $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
            }
            else if (2 * FuelConsumption > FuelTank.CurrentCapacity && FuelTank.CurrentCapacity > 0)
            {
                if (FuelConsumption < FuelTank.CurrentCapacity)
                {
                    Console.WriteLine($"You were too scared to race, as you were low on fuel " +
                                      $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity}), so instead you drove " +
                                      $"your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} to" +
                                      $"the closest gas station. (-{FuelConsumption} units of fuel)");
                    FuelTank.CurrentCapacity -= (int)FuelConsumption;
                }
                else
                {
                    Console.WriteLine($"Your car has just run out of fuel. Thankfully, good people of the road " +
                                      $"helped to push your car to the closest gas station. (you would have " +
                                      $"{FuelTank.CurrentCapacity - (int)FuelConsumption}/{FuelTank.MaxCapacity})");
                    FuelTank.CurrentCapacity = 0;
                }
            }
            else
            {
                if (4 * FuelConsumption >= FuelTank.CurrentCapacity)
                {
                    Console.WriteLine($"You should visit the gas station, your fuel tank is running dry! " +
                                      $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
                }
                Console.WriteLine($"You are blazing through the land in your {VehicleColor.ToLower()} " +
                                  $"{VehicleModel}, aiming for new speed record! " +
                                  $"(-{(int)(2 * FuelConsumption)} units of fuel)");
                FuelTank.CurrentCapacity -= (int)(2 * FuelConsumption);
            }
        }
    }
}
