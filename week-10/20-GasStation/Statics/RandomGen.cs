using System;
using _20_GasStation.Vehicles;

namespace _20_GasStation.Statics
{
    internal static class RandomGen
    {
        // Fuel Reservoir
        public static FuelReservoir.Type FuelType()
        {
            Random fuelTypeRnd = new Random();
            var fuelTypes = Enum.GetValues(typeof(FuelReservoir.Type));
            return (FuelReservoir.Type)fuelTypeRnd.Next(fuelTypes.Length);
        }

        // Gas Station
        public static GasStation.Size StationSize()
        {
            Random sizeRnd = new Random();
            var sizes = Enum.GetValues(typeof(GasStation.Size));
            return (GasStation.Size)sizeRnd.Next(sizes.Length);
        }

        public static float FuelPrice(int priceMin, int priceMax)
        {
            Random priceRnd = new Random();
            return priceRnd.Next((priceMin * 100), (priceMax * 100) + 1) / 100.0f;
        }

        public static string CompanyName()
        {
            Random companyRnd = new Random();
            string[] companies = { "Benzina", "MOL", "EuroOil", "Shell", "OMV", "Agip" };
            
            return companies[companyRnd.Next(companies.Length)];
        }

        // Vehicles
        public static Vehicle.Type VehicleType()
        {
            Random vehicleRnd = new Random();
            var vehicles = Enum.GetValues(typeof(Vehicle.Type));
            return (Vehicle.Type)vehicleRnd.Next(vehicles.Length);
        }

        public static Vehicle.Color VehicleColor()
        {
            Random colorRnd = new Random();
            var colors = Enum.GetValues(typeof(Vehicle.Color));
            return (Vehicle.Color)colorRnd.Next(colors.Length);
        }

        public static string VehicleModel(Vehicle.Type type)
        {
            Random modelRnd = new Random();
            string[] models;
            switch (type)
            {
                case Vehicle.Type.Car:
                    models = new string[]{ "Skoda Fabia", "Skoda Octavia", "Ford Mondeo", "Ford Focus",
                                           "Peugeot 208", "Renault Megane", "Renault Clio", "Citroen C5", 
                                           "Honda Civic", "Hyundai i30", "Audi A3", "Fiat Punto",
                                           "Volkswagen Golf", "Volkswagen Passat", "Opel Astra" };
                    return models[modelRnd.Next(models.Length)];
                case Vehicle.Type.SportsCar:
                    models = new string[]{ "Audi R8 V10", "Nissan GT-R Proto", "Ferrari F50", "Bugatti Veyron",
                                           "McLaren Senna", "Dodge Charger","Dodge Viper", "Shelby Mustang",
                                           "Chevrolet Camaro","Chevrolet Corvette", "Lamborghini Gallardo",
                                           "Porsche 911 GT3", "Aston Martin DB11", "Bentley Continental GT",
                                           "Mercedes SL65 AMG"};
                    return models[modelRnd.Next(models.Length)];
                case Vehicle.Type.SUV:
                    models = new string[] { "BMW X6 M", "Hummer H1", "Porsche Cayenne", "Audi Q8", 
                                            "Jeep Grand Cherokee", "Cadillac Escalade", "Nissan Titan",
                                            "Ford F-150 Raptor", "Land Rover Defender"};
                    return models[modelRnd.Next(models.Length)];
                case Vehicle.Type.Bike:
                    models = new string[]{ "Yamaha YZF-R1", "Bimota BB3", "Ducati Panigale S", "BMW S1000RR",
                                           "Ducati Desmosedici", "Honda CBR Fireblade", "Kawasaki Ninja ZX"};
                    return models[modelRnd.Next(models.Length)];
                case Vehicle.Type.Truck:
                case Vehicle.Type.Cistern:
                    models = new string[]{ "Renault Magnum", "Mercedes Actros", "Volvo FH12", "DAF XF105",
                                           "MAN TGX-D38", "Scania Streamline", "Iveco Stralis"};
                    return models[modelRnd.Next(models.Length)];
                default:
                    return "[unknown]";
            }
        }
    }
}
