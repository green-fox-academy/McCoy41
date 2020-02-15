using System;
using _20_GasStation.Vehicles;

namespace _20_GasStation.Statics
{
    static class GetInfo
    {
        public const int defaultUnit = 10;
        public enum Detail { Random, Fuel, WithModel, WithColor };

        // Fuel Reservoir
        public static int TankCapacity(Vehicle.Type vehicle)
        {
            switch (vehicle)
            {
                case Vehicle.Type.Bike:
                    return 8 * defaultUnit;
                case Vehicle.Type.SUV:
                    return 15 * defaultUnit;
                case Vehicle.Type.Truck:
                    return 25 * defaultUnit;
                case Vehicle.Type.Cistern:
                    return TankCapacity(GasStation.Size.Regular) + TankCapacity(Vehicle.Type.Truck);
                default:
                    return 10 * defaultUnit;
            }
        }

        public static int TankCapacity(GasStation.Size size)
        {
            switch (size)
            {
                case GasStation.Size.Small:
                    return 100 * defaultUnit;
                case GasStation.Size.Large:
                    return 400 * defaultUnit;
                case GasStation.Size.Central:
                    return 800 * defaultUnit;
                default:
                    return 250 * defaultUnit;
            }
        }

        public static FuelReservoir.Type FuelType()
        {
            FuelReservoir.Type random = RandomGen.FuelType();
            int fuelTypes = Enum.GetValues(typeof(FuelReservoir.Type)).Length;
            Console.WriteLine("Please specify the fuel type:");
            for (int i = 0; i < fuelTypes; i++)
            {
                Console.WriteLine($" {i+1} - {((FuelReservoir.Type)i).ToString()}");
            }
            
            int.TryParse(Console.ReadLine(), out int fuel);
            if (fuel > 0 && fuel <= fuelTypes)
            {
                Console.WriteLine($"// {((FuelReservoir.Type)fuel - 1).ToString()} station selected");
                return (FuelReservoir.Type)(fuel - 1);
            }
            else
            {
                Console.WriteLine($"// {random.ToString()} station randomly selected");
                return random;
            }
        }

        // Gas Station
        public static GasStation.Size StationSize()
        {
            GasStation.Size random = RandomGen.StationSize();
            int stationSizes = Enum.GetValues(typeof(GasStation.Size)).Length;
            Console.WriteLine("Please specify size of the new gas station:");
            for (int i = 0; i < stationSizes; i++)
            {
                Console.WriteLine($" {i+1} - {((GasStation.Size) i).ToString()} station " +
                                  $"(capacity of {TankCapacity((GasStation.Size) i)} units)");
            }
            
            int.TryParse(Console.ReadLine(), out int size);
            if (size > 0 && size <= stationSizes)
            {
                Console.WriteLine($"// {((GasStation.Size)size - 1).ToString()} station selected");
                return (GasStation.Size)(size - 1);
            }
            else
            {
                Console.WriteLine($"// {random.ToString()} station randomly selected");
                return random;
            }
        }
        public static string StationName()
        {
            Console.WriteLine("Please specify gas station name (or leave empty to generate name randomly):");
            string name = Console.ReadLine();
            if (name == "" || name == null)
            {
                name = RandomGen.CompanyName();
                Console.WriteLine($"Let the gas station name be {name}!");
            }
            return name;
        }

        // Vehicles
        public static Vehicle.Type VehicleType(out Detail detail)
        {
            Vehicle.Type random = RandomGen.VehicleType();
            int vehicleTypes = Enum.GetValues(typeof(Vehicle.Type)).Length;
            Console.WriteLine("What vehicle would you like?!");
            for (int i = 0; i < vehicleTypes; i++)
            {
                Console.WriteLine($" {i + 1} - {(Vehicle.Type)i}");
            }
            
            int.TryParse(Console.ReadLine(), out int vehicle);
            if (vehicle > 0 && vehicle <= vehicleTypes)
            {
                detail = GetDetail();
                return (Vehicle.Type)(vehicle - 1);
            }
            else
            {
                Console.WriteLine($"// Mr.Random gave you his {random.ToString().ToLower()}");
                detail = Detail.Random;
                return random;
            }
        }

        public static Detail GetDetail()
        {
            Console.WriteLine("How much to the detail do you want to go?");
            Console.WriteLine(" 1 - I want to adjust EVERYTHING!");
            Console.WriteLine(" 2 - Car color could be skipped...");
            Console.WriteLine(" 3 - Let me at least specify the fuel type.");
            Console.WriteLine(" <other> - I DON'T CARE!");

            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return Detail.WithColor;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return Detail.WithModel;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return Detail.Fuel;
                default:
                    return Detail.Random;
            }
        }

        public static string VehicleModel(Vehicle.Type type)
        {
            Console.WriteLine("So what you want to drive?");
            string model = Console.ReadLine();
            if (model == "" || model == null)
            {
                model = RandomGen.VehicleModel(type);
                Console.WriteLine($"Mister Random gave you keys from {model}!");
            }
            return model;
        }

        public static string VehicleColor()
        {
            Console.WriteLine("Give me the color:");
            string color = Console.ReadLine();
            if (color == "" || color == null)
            {
                color = RandomGen.VehicleColor().ToString().ToLower();
                Console.WriteLine($"Let the gas station name be {color}!");
            }
            return color;
        }
    }
}