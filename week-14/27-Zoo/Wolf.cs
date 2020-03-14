using System;
using System.Collections.Generic;
using System.Text;

namespace _27_Zoo
{
    class Wolf : Animal
    {
        public Wolf(string name) : base(name)
        {
            Herbivore = false;
            FoodConsumption = 1;
            MaxConsumption = 4;
            BellyMaxCapacity = 5;
            BellyCurrentLevel = BellyMaxCapacity;
        }
    }
}
