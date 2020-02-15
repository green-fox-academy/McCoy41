using System;
using _20_GasStation.Vehicles;

namespace _20_GasStation.Statics
{
    static class GetInfo
    {
        public static GasStation.Size StationSize()
        {
            GasStation.Size random = RandomGen.StationSize();
            int stationSizes = Enum.GetValues(typeof(GasStation.Size)).Length;
            Console.WriteLine("Please specify size of the new gas station:");
            for (int i = 0; i < stationSizes; i++)
            {
                Console.WriteLine($" {i+1} - {((GasStation.Size) i).ToString()} station " +
                                  $"(capacity of {(GasStation.Size) i} units)");
            }
            int.TryParse(Console.ReadLine(), out int size);

            if (size > 0 && size <= stationSizes)
            {
                Console.WriteLine($"// {((GasStation.Size)size - 1).ToString()} station selected");
                return (GasStation.Size)(size - 1);
            }
            else
            {
                Console.WriteLine($"// {random.ToString()} station selected");
                return random;
            }
        }

        public static string StationName()
        {
            Console.WriteLine("Please specify gas station name (or leave empty to generate name randomly):");
            string name = Console.ReadLine();
            if (name == "" || name == null) return RandomGen.CompanyName();
            else return name;
        }
    }
}
