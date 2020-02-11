using System;

namespace _19_Dices
{
    class DiceSet
    {
        private Random randomValue = new Random();
        private int[] dice = new int[6];

        public int[] Roll()
        {
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = randomValue.Next(1, 7);
            }

            return dice;
        }

        public int[] GetCurrent()
        {
            return dice;
        }

        public int GetCurrent(int i)
        {
            return dice[i];
        }

        public void Reroll()
        {
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = randomValue.Next(1, 7);
            }
        }

        public void Reroll(int k)
        {
            dice[k] = randomValue.Next(1, 7);
        }

    }
}
