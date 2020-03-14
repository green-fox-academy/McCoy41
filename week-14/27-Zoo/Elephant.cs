using System;
using System.Collections.Generic;
using System.Text;

namespace _27_Zoo
{
    class Elephant : Animal
    {
        public Elephant(string name) : base(name)
        {
            Herbivore = true;
            FoodConsumption = 5;
            MaxConsumption = 20;
            BellyMaxCapacity = 40;
            BellyCurrentLevel = BellyMaxCapacity;
        }
    }
}
