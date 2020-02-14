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

            Prices = GetRandomPrices(1, 5);
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

        static string GetRandomCompanyName()
        {
            string[] companies = { "Benzina", "MOL", "EuroOil", "Shell", "OMV", "Agip" };
            Random rndCompany = new Random();

            return companies[rndCompany.Next(0, companies.Length)];
        }

        float[] GetRandomPrices(int priceMin, int priceMax)
        {
            float[] prices = new float[FuelTanks.Count];

            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] = GetRandomPrice(priceMin, priceMax);
            }

            return prices;
        }

        float GetRandomPrice(int priceMin, int priceMax)
        {
            Random rndPrice = new Random();
            return rndPrice.Next((priceMin * 100), (priceMax * 100) + 1) / 100.0f;
        }

        public override string ToString()
        {
            string text = $"\nWelcome to {CompanyName}!\n";
            for (int i = 0; i < FuelTanks.Count; i++)
            {
                text += $"\n{ FuelTanks[i].FuelType.ToString()} " +
                        $"({FuelTanks[i].CurrentCapacity}/{FuelTanks[i].MaxCapacity})" +
                        $"\nPrice: {Prices[i]:0.00} Cr. per unit";
            }
            return text;
        }

        void SetNewPrice(FuelType fuel, float price, bool overwrite)
        {
            float priceNew = overwrite ? price : price + Prices[(int)fuel];

            if (priceNew > 0 && priceNew < 10) Prices[(int)fuel] = priceNew;
            else Console.WriteLine($"WARNING: Unable to update price of {fuel.ToString().ToLower()}");
        }

        public void PriceUpdate(FuelType fuel, float priceChange, bool discount)
        {
            SetNewPrice(fuel, discount ? -priceChange : priceChange, false);
        }

        public void PriceUpdate(FuelType fuel, bool discount)
        {
            PriceUpdate(fuel, GetRandomPrice(0, 2), discount);
        }

        public void PriceUpdate(FuelType fuel, float priceNew)
        {
            SetNewPrice(fuel, priceNew, true);
        }

        public void PriceUpdate(FuelType fuel)
        {
            PriceUpdate(fuel, GetRandomPrice(1, 5));
        }

        public void PriceUpdate(float priceChange, bool discount)
        {
            for (int i = 0; i < Prices.Length; i++)
            {
                SetNewPrice((FuelType)i, discount ? -priceChange : priceChange, false);
            }
        }

        public void PriceUpdate(bool discount)
        {
            PriceUpdate(GetRandomPrice(0, 1), discount);
        }

        public void PriceUpdate()
        {
            for (int i = 0; i < Prices.Length; i++)
            {
                SetNewPrice((FuelType)i,GetRandomPrice(1, 5), true);
            }
        }

        void SetNewFuel(FuelType fuel, int amount, bool overwrite)
        {
            int amountNew = overwrite ? amount : amount + FuelTanks[(int)fuel].CurrentCapacity;

            if (amountNew > FuelTanks[(int)fuel].MaxCapacity)
            {
                FuelTanks[(int)fuel].CurrentCapacity = FuelTanks[(int)fuel].MaxCapacity;
                Console.WriteLine($"WARNING: {amountNew - FuelTanks[(int)fuel].MaxCapacity} " +
                                  $"units of {fuel.ToString().ToLower()} overflowed!");
            }
            else if (amountNew <= 0)
            {
                FuelTanks[(int)fuel].CurrentCapacity = 0;
                Console.WriteLine($"WARNING: {fuel.ToString()} tank is empty! " +
                                  $"(status of tank would be {amountNew})");
            }
            else FuelTanks[(int)fuel].CurrentCapacity = amountNew;
        }

        public void RefillTank(FuelType fuel)
        {
            SetNewFuel(fuel, FuelTanks[(int)fuel].MaxCapacity, true);
        }

        public void RefillTank(FuelType fuel, uint amount)
        {
            SetNewFuel(fuel, (int)amount, false);
        }

        public void RefillTank()
        {
            for (int i = 0; i < FuelTanks.Count; i++)
            {
                RefillTank((FuelType)i);
            }
        }

        public void RefillTank(uint amount)
        {
            for (int i = 0; i < FuelTanks.Count; i++)
            {
                RefillTank((FuelType)i, amount);
            }
        }

        public void EmptyTank(FuelType fuel, uint amount)
        {
            SetNewFuel(fuel, -(int)amount, false);
        }
    }
}
