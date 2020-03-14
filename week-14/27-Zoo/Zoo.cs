using System;
using System.Collections.Generic;
using System.Text;

namespace _27_Zoo
{
    class Zoo
    {
        private int StockMeat;
        private int StockVeggie;
        private int DirtLevel;
        private List<Animal> Animals;
        public Zoo()
        {
            StockMeat = 100;
            StockVeggie = 100;
            DirtLevel = 0;
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void FeedAllAnimals()
        {
            foreach (var animal in Animals)
            {
                if (animal.IsHerbivore())
                {
                    StockVeggie -= animal.Eat(StockVeggie);
                }
                else
                {
                    StockMeat -= animal.Eat(StockMeat);
                }
            }
        }

        public void RefillFood(int amount)
        {
            StockMeat += amount;
            StockVeggie += amount;
        }

        public void SpendNormalDay()
        {
            foreach (var animal in Animals)
            {
                DirtLevel += animal.Run() + animal.Live();
            }
        }

        public void SpendQuarantineDay()
        {
            foreach (var animal in Animals)
            {
                DirtLevel += animal.Live();
            }
        }

        public string GetTheFullestStatus(bool filterHerbivore)
        {
            int minValue = 1000;
            int leastHungry = -1; 
            for (int i = 0; i < Animals.Count; i++)
            {
                int currentValue = Animals[i].GetHunger();
                if (filterHerbivore && Animals[i].IsHerbivore()) continue;
                if (currentValue < minValue)
                {
                    minValue = currentValue;
                    leastHungry = i;
                }
            }
            return (leastHungry == -1) ? "" : Animals[leastHungry].GetStatus();
        }
    }
}
