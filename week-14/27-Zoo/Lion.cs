using System;
using System.Collections.Generic;
using System.Text;

namespace _27_Zoo
{
    class Lion : Animal
    {
        public Lion(string name) : base(name)
        {
            Herbivore = false;
            FoodConsumption = 2;
            MaxConsumption = 8;
            BellyMaxCapacity = 10;
            BellyCurrentLevel = BellyMaxCapacity;
        }
    }
}
