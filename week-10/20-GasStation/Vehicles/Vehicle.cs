using System;
using _20_GasStation.Statics;

namespace _20_GasStation.Vehicles
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
    


    








}
