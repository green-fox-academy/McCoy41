using System;
using System.Collections.Generic;
using System.Text;

namespace _27_Zoo
{
    abstract class Animal
    {
        protected string Name;
        protected bool Herbivore;
        protected int FoodConsumption;
        protected int MaxConsumption;
        protected int BellyCurrentLevel;
        protected int BellyMaxCapacity;

        public Animal(string name)
        {
            Name = name;
        }

        public bool IsHerbivore()
        {
            return Herbivore;
        }

        public int GetHunger()
        {
            return BellyMaxCapacity - BellyCurrentLevel;
        }

        public int Eat(int amount)
        {
            if (amount > FoodConsumption)
            {
                Console.WriteLine($"It's too much for {Name}! Some food has been left...");
                amount = FoodConsumption;
            }
            else if (amount < 0) amount = 0;
            BellyCurrentLevel += amount;
            return amount;
        }

        public int Live()
        {
            return Eat(FoodConsumption);
        }

        public int Run()
        {
            return Eat(3 * FoodConsumption);
        }

        public string GetStatus()
        {
            string herbivoire = IsHerbivore() ? "Herbivoire" : "Carnivore";
            return $"Name: {Name}" +
                   $"\nHunger Level: {GetHunger()}" +
                   $"\n{herbivoire}";
        }
    }
}
