using System;
using System.Collections.Generic;
using _20_GasStation.Statics;

namespace _20_GasStation
{
    
    internal class GasStation
    {
        public enum Size { Small, Regular, Large, Central }
        public List<FuelReservoir> FuelTanks;
        public string CompanyName;
        public float[] Prices;

        public GasStation(Size size, string company)
        {
            FuelTanks = new List<FuelReservoir>();
            for (int i = 0; i < Enum.GetValues(typeof(FuelReservoir.Type)).Length; i++)
            {
                FuelTanks.Add(new FuelReservoir(size, (FuelReservoir.Type)i));
            }

            Prices = FuelPrices(1, 5);
            CompanyName = company;
        }

        public GasStation(string company)
            : this(RandomGen.StationSize(), company)
        { }

        public GasStation(Size size)
            : this(size, RandomGen.CompanyName())
        { }

        public GasStation()
            : this(RandomGen.StationSize())
        { }

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

        public float[] FuelPrices(int priceMin, int priceMax)
        {
            float[] prices = new float[FuelTanks.Count];

            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] = RandomGen.FuelPrice(priceMin, priceMax);
            }

            return prices;
        }

        void SetNewPrice(FuelReservoir.Type fuel, float price, bool overwrite)
        {
            float priceNew = overwrite ? price : price + Prices[(int)fuel];

            if (priceNew > 0 && priceNew < 10) Prices[(int)fuel] = priceNew;
            else Console.WriteLine($"WARNING: Unable to update price of {fuel.ToString().ToLower()}");
        }

        public void PriceUpdate(FuelReservoir.Type fuel, float priceChange, bool discount)
        {
            SetNewPrice(fuel, discount ? -priceChange : priceChange, false);
        }

        public void PriceUpdate(FuelReservoir.Type fuel, bool discount)
        {
            PriceUpdate(fuel, RandomGen.FuelPrice(0, 2), discount);
        }

        public void PriceUpdate(FuelReservoir.Type fuel, float priceNew)
        {
            SetNewPrice(fuel, priceNew, true);
        }

        public void PriceUpdate(FuelReservoir.Type fuel)
        {
            PriceUpdate(fuel, RandomGen.FuelPrice(1, 5));
        }

        public void PriceUpdate(float priceChange, bool discount)
        {
            for (int i = 0; i < Prices.Length; i++)
            {
                SetNewPrice((FuelReservoir.Type)i, discount ? -priceChange : priceChange, false);
            }
        }

        public void PriceUpdate(bool discount)
        {
            PriceUpdate(RandomGen.FuelPrice(0, 1), discount);
        }

        public void PriceUpdate()
        {
            for (int i = 0; i < Prices.Length; i++)
            {
                SetNewPrice((FuelReservoir.Type)i, RandomGen.FuelPrice(1, 5), true);
            }
        }

        void SetNewFuel(FuelReservoir.Type fuel, int amount, bool overwrite)
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
                Console.WriteLine($"WARNING: {fuel.ToString()} tank is empty!" +
                                  $"{(amountNew == 0 ? "" : $" (status of tank would be {amountNew})")}");
            }
            else FuelTanks[(int)fuel].CurrentCapacity = amountNew;
        }

        public void RefillTank(FuelReservoir.Type fuel)
        {
            SetNewFuel(fuel, FuelTanks[(int)fuel].MaxCapacity, true);
        }

        public void RefillTank(FuelReservoir.Type fuel, uint amount)
        {
            SetNewFuel(fuel, (int)amount, false);
        }

        public void RefillTank()
        {
            for (int i = 0; i < FuelTanks.Count; i++)
            {
                RefillTank((FuelReservoir.Type)i);
            }
        }

        public void RefillTank(uint amount)
        {
            for (int i = 0; i < FuelTanks.Count; i++)
            {
                RefillTank((FuelReservoir.Type)i, amount);
            }
        }

        public void EmptyTank(FuelReservoir.Type fuel, uint amount)
        {
            SetNewFuel(fuel, -(int)amount, false);
        }
    }
}
