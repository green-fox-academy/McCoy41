using System;
using _20_GasStation.Statics;

namespace _20_GasStation.Vehicles
{
    class SportsCar : Car
    {
        public SportsCar(string model, string color, FuelReservoir.Type fuel, Type type = Type.SportsCar)
            : base(model, color, fuel, type)
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

        public virtual void Race(float modifier = 2.5f)
        {
            if (FuelTank.CurrentCapacity == 0)
            {
                Console.WriteLine($"Your {VehicleColor.ToLower().Replace("_", " ")} {VehicleModel} majestically " +
                                  $"stands in the middle of the road... " +
                                  $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
            }
            else if (modifier * FuelConsumption > FuelTank.CurrentCapacity && FuelTank.CurrentCapacity > 0)
            {
                if (FuelConsumption < FuelTank.CurrentCapacity)
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
                if (2 * modifier * FuelConsumption >= FuelTank.CurrentCapacity)
                {
                    Console.WriteLine($"You should visit the gas station, your fuel tank is running dry! " +
                                      $"({FuelTank.CurrentCapacity}/{FuelTank.MaxCapacity})");
                }
                Console.WriteLine($"You are blazing through the land in your {VehicleColor.ToLower()} " +
                                  $"{VehicleModel}, aiming for new speed record! " +
                                  $"(-{(int)(modifier * FuelConsumption)} units of fuel)");
                FuelTank.CurrentCapacity -= (int)(modifier * FuelConsumption);
            }
        }
    }
}
