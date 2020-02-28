using System;
using System.Collections.Generic;
using System.Text;

namespace _23_Dominoes
{
    static class Randomizer
    {
        public static int RndValue()
        {
            Random rndVal = new Random();
            return rndVal.Next(DefaultValues.min, DefaultValues.max + 1);
        }

        public static int RndCount(int maxCount = DefaultValues.maxCount)
        {
            Random rndCount = new Random();
            return rndCount.Next(1, maxCount + 1);
        }
    }
}
