using System;
using System.Collections.Generic;

namespace _20_GasStation
{
    public enum StationSize { Small, Regular, Large, Central }
    class GasStation
    {
        public List<FuelReservoir> FuelTanks;
        public string CompanyName;
        public float[] Prices;

        public GasStation(StationSize size)
        {
            FuelTanks = new List<FuelReservoir>();
            FuelTanks.Add(new FuelReservoir(FuelType.Gasoline, size));
            FuelTanks.Add(new FuelReservoir(FuelType.Diesel, size));
            FuelTanks.Add(new FuelReservoir(FuelType.Ethanol, size));
            FuelTanks.Add(new FuelReservoir(FuelType.LPG, size));
            FuelTanks.Add(new FuelReservoir(FuelType.Hydrogen, size));

            Prices = GetRandomPrices(1, 5, 5);
            CompanyName = GetRandomCompanyName();
        }

        public GasStation()
            : this(StationSize.Regular)
        { }

        static float[] GetRandomPrices(int priceMin, int priceMax, int amount)
        {
            float[] prices = new float[amount];
            Random rndPrice = new Random();

            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] = rndPrice.Next((priceMin * 100), (priceMax * 100) + 1) / 100.0f;
            }
            
            return prices;
        }

        static string GetRandomCompanyName()
        {
            string[] companies = { "Benzina", "MOL", "EuroOil", "Shell", "OMV", "Agip" };
            Random rndCompany = new Random();

            return companies[rndCompany.Next(0, companies.Length)];
        }

        public static void PrintStatus(List<FuelReservoir> fuelTanks, float[] prices, string companyName)
        {
            Console.WriteLine($"\nWelcome to {companyName} gas station\n");
            Console.WriteLine("Prices are following:");
            for (int i = 0; i < fuelTanks.Count; i++)
            {
                Console.WriteLine($"{fuelTanks[i].FuelType.ToString()}: {prices[i]} USD per unit");
            }
            Console.WriteLine();
            Console.WriteLine("The status of fueltanks is following:");
            for (int i = 0; i < fuelTanks.Count; i++)
            {
                Console.WriteLine($"{fuelTanks[i].FuelType.ToString()}: {fuelTanks[i].CurrentCapacity}/" +
                                  $"{fuelTanks[i].MaxCapacity}");
            }
            Console.WriteLine();
        }
    }
}
