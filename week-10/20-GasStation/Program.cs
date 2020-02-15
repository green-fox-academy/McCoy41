using System;
using _20_GasStation.Vehicles;
using _20_GasStation.Statics;

namespace _20_GasStation
{
    
    class Program
    {
        static void Main(string[] args)
        {
            /*
            GasStation station1 = new GasStation(GasStation.Size.Large,"McGass");
            station1.EmptyTank(FuelReservoir.Type.Gasoline, 200);
            station1.EmptyTank(FuelReservoir.Type.Diesel, 250);
            station1.EmptyTank(FuelReservoir.Type.Ethanol, 50);
            station1.EmptyTank(FuelReservoir.Type.LPG, 650);
            station1.EmptyTank(FuelReservoir.Type.Hydrogen, 5000);
            Console.WriteLine(station1.ToString());

            for (int i = 0; i < 10; i++)
            {
                Vehicle vehicle = new Vehicle();
                Console.WriteLine(vehicle.ToString());
            }

            Bike vehicle1 = new Bike();
            Console.WriteLine(vehicle1.ToString());
            vehicle1.Race();
            vehicle1.Horn();
            vehicle1.Refuel(station1,25);
            vehicle1.Race();
            vehicle1.Race();
            vehicle1.Drive();

            Cistern vehicle2 = new Cistern(FuelReservoir.Type.Hydrogen);
            vehicle2.Horn();
            vehicle2.SupplyFuel(station1);
            Console.WriteLine(vehicle2.ToString());
            */

            Console.WriteLine("Welcome to GasStation excersise!");
            Console.WriteLine("\nTo begin, you will have to first generate new station and your first vehicle...");
            GasStation station = NewGasStation();
            Vehicle vehicle;
            GetInfo.Detail detail;
            switch (GetInfo.VehicleType(out detail))
            {
                case Vehicle.Type.SportsCar:
                    vehicle = NewSportsCar(detail);
                    break;
                case Vehicle.Type.SUV:
                    vehicle = NewSUV(detail);
                    break;
                case Vehicle.Type.Bike:
                    vehicle = NewBike(detail);
                    break;
                case Vehicle.Type.Truck:
                    vehicle = NewTruck(detail);
                    break;
                case Vehicle.Type.Cistern:
                    vehicle = NewCistern(detail);
                    break;
                case Vehicle.Type.Car:
                default:
                    vehicle = NewCar(detail);
                    break;
            }

            Console.WriteLine(vehicle.ToString());
            Console.WriteLine(station.ToString());
        }

        static Car NewCar(GetInfo.Detail detail)
        {
            switch (detail)
            {
                case GetInfo.Detail.Fuel:
                    return new Car(GetInfo.FuelType());
                case GetInfo.Detail.WithModel:
                    return new Car(GetInfo.VehicleModel(Vehicle.Type.Car),GetInfo.FuelType());
                case GetInfo.Detail.WithColor:
                    return new Car(GetInfo.VehicleModel(Vehicle.Type.Car), GetInfo.VehicleColor(),
                                   GetInfo.FuelType());
                default:
                    return new Car();
            }
        }

        static SportsCar NewSportsCar(GetInfo.Detail detail)
        {
            switch (detail)
            {
                case GetInfo.Detail.Fuel:
                    return new SportsCar(GetInfo.FuelType());
                case GetInfo.Detail.WithModel:
                    return new SportsCar(GetInfo.VehicleModel(Vehicle.Type.SportsCar),GetInfo.FuelType());
                case GetInfo.Detail.WithColor:
                    return new SportsCar(GetInfo.VehicleModel(Vehicle.Type.SportsCar), GetInfo.VehicleColor(),
                                         GetInfo.FuelType());
                default:
                    return new SportsCar();
            }
        }
        
        static SUV NewSUV(GetInfo.Detail detail)
        {
            switch (detail)
            {
                case GetInfo.Detail.Fuel:
                    return new SUV(GetInfo.FuelType());
                case GetInfo.Detail.WithModel:
                    return new SUV(GetInfo.VehicleModel(Vehicle.Type.SUV),GetInfo.FuelType());
                case GetInfo.Detail.WithColor:
                    return new SUV(GetInfo.VehicleModel(Vehicle.Type.SUV), GetInfo.VehicleColor(),
                                   GetInfo.FuelType());
                default:
                    return new SUV();
            }
        }
        
        static Bike NewBike(GetInfo.Detail detail)
        {
            switch (detail)
            {
                case GetInfo.Detail.Fuel:
                    return new Bike(GetInfo.FuelType());
                case GetInfo.Detail.WithModel:
                    return new Bike(GetInfo.VehicleModel(Vehicle.Type.Bike),GetInfo.FuelType());
                case GetInfo.Detail.WithColor:
                    return new Bike(GetInfo.VehicleModel(Vehicle.Type.Bike), GetInfo.VehicleColor(),
                                    GetInfo.FuelType());
                default:
                    return new Bike();
            }
        }
        
        static Truck NewTruck(GetInfo.Detail detail)
        {
            switch (detail)
            {
                case GetInfo.Detail.Fuel:
                    return new Truck(GetInfo.FuelType());
                case GetInfo.Detail.WithModel:
                    return new Truck(GetInfo.VehicleModel(Vehicle.Type.Truck),GetInfo.FuelType());
                case GetInfo.Detail.WithColor:
                    return new Truck(GetInfo.VehicleModel(Vehicle.Type.Truck), GetInfo.VehicleColor(),
                                     GetInfo.FuelType());
                default:
                    return new Truck();
            }
        }

        static Truck NewCistern(GetInfo.Detail detail)
        {
            switch (detail)
            {
                case GetInfo.Detail.Fuel:
                    return new Cistern(GetInfo.FuelType());
                case GetInfo.Detail.WithModel:
                    return new Cistern(GetInfo.VehicleModel(Vehicle.Type.Cistern), GetInfo.FuelType());
                case GetInfo.Detail.WithColor:
                    return new Cistern(GetInfo.VehicleModel(Vehicle.Type.Cistern), GetInfo.VehicleColor(),
                                       GetInfo.FuelType());
                default:
                    return new Cistern();
            }
        }

        static GasStation NewGasStation()
        {
            return new GasStation(GetInfo.StationSize(), GetInfo.StationName());
        }
    }
}
