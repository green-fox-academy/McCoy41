using System;
using System.Collections.Generic;
using System.Text;

namespace _23_Dominoes
{
    class Domino : IComparable
    {
        public int[] Value { get; private set; }

        public Domino(int a = -1, int b = -1)
        {
            if (a < DefaultValues.min || a > DefaultValues.max) a = Randomizer.RndValue();
            if (b < DefaultValues.min || b > DefaultValues.max) b = Randomizer.RndValue();

            Value = new int[] { a, b };
        }

        public override string ToString()
        {
            return $"[{Value[0]}|{Value[1]}]";
        }

        public Domino Rotate()
        {
            return new Domino(Value[1], Value[0]);
        }

        public int CompareTo(object obj)
        {
            if (obj is Domino)
            {
                if (((Domino)obj).Value[0] == Value[0])
                {
                    return Value[1] - ((Domino)obj).Value[1];
                }
                return Value[0] - ((Domino)obj).Value[0];
            }
            else return 0;
        }
    }
}
