using System;
using System.Linq;

namespace _19_Dices
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceSet diceSet = new DiceSet();
            diceSet.Roll();
            for (int i = 0; i < diceSet.GetCurrent().Length; i++)
            {
                PrintStatus(diceSet, i);
            }
            Console.WriteLine($"It took {AutoRoll(diceSet,6)} attempts to get this result.");

        }
        static void PrintStatus(DiceSet diceSet)
        {
            int[] dices = diceSet.GetCurrent();

            for (int i = 0; i < dices.Length; i++)
            {
                if (i == 0) Console.Write(dices[i]);
                else Console.Write($" | {dices[i]}");
            }

            Console.WriteLine();
        }
        static void PrintStatus(DiceSet diceSet, int position)
        {
            Console.WriteLine($"Number on the dice #{position + 1} is {diceSet.GetCurrent(position)}.");
        }


        static int AutoRoll(DiceSet diceSet, int goal)
        {
            int attempts = 0;
            int[] dices = diceSet.GetCurrent();
            bool[] numOk = NumOkMap(dices, goal);

            while (!numOk.SequenceEqual(Enumerable.Repeat(true, dices.Length).ToArray()))
            {
                for (int i = 0; i < dices.Length; i++)
                {
                    if (numOk[i] == false) diceSet.Reroll(i);
                }
                numOk = NumOkMap(dices, goal);
                PrintStatus(diceSet);
                attempts++;
            }

            return attempts;
        }
        static bool[] NumOkMap(int[] dices, int goal)
        {
            bool[] numOk = new bool[dices.Length];

            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i] == goal) numOk[i] = true;
                else numOk[i] = false;
            }

            return numOk;
        }
    }
}
