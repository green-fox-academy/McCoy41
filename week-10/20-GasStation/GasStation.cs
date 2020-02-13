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

        public GasStation(StationSize size, string company)
        {
            FuelTanks = new List<FuelReservoir>();
            FuelTanks.Add(new FuelReservoir(FuelType.Gasoline, size));
            FuelTanks.Add(new FuelReservoir(FuelType.Diesel, size));
            FuelTanks.Add(new FuelReservoir(FuelType.Ethanol, size));
            FuelTanks.Add(new FuelReservoir(FuelType.LPG, size));
            FuelTanks.Add(new FuelReservoir(FuelType.Hydrogen, size));

            Prices = GetRandomPrices(1, 5, FuelTanks.Count);
            CompanyName = company;
        }

        public GasStation(string company)
            : this(StationSize.Regular, company)
        { }

        public GasStation(StationSize size)
            : this(size, GetRandomCompanyName())
        { }

        public GasStation()
            : this(StationSize.Regular, GetRandomCompanyName())
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

        public override string ToString()
        {
            string text = $"\nWelcome to {CompanyName}!\n";
            for (int i = 0; i < Prices.Length; i++)
            {
                text += $"\n{ FuelTanks[i].FuelType.ToString()} " +
                        $"({FuelTanks[i].CurrentCapacity}/{FuelTanks[i].MaxCapacity})" +
                        $"\nPrice: {Prices[i]:0.00} Cr. per unit";
            }
            return text;
        }
    }
}
