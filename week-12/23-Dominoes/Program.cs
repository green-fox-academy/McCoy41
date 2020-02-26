using System;
using System.Collections.Generic;

namespace _23_Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Domino> dominos = GetDominos(Randomizer.RndCount(10));
            Console.WriteLine("Generated List:");
            foreach (var domino in dominos)
            {
                Console.Write(" " + domino);
            }

            Console.WriteLine();
            Console.WriteLine();

            dominos.Sort();
            Console.WriteLine("Sorted List:");
            foreach (var domino in dominos)
            {
                Console.Write(" " + domino);
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < dominos.Count; i++)
            {
                if (dominos[i].Value[0] > dominos[i].Value[1]) dominos[i] = dominos[i].Rotate();
            }
            dominos.Sort();

            Console.WriteLine("Sorted List (with rotation):");
            foreach (var domino in dominos)
            {
                Console.Write(" " + domino);
            }
            Console.WriteLine();
        }

        static List<Domino> GetDominos() // from syllabus
        {
            List<Domino> dominos = new List<Domino>(6);
            dominos.Add(new Domino(5, 2));
            dominos.Add(new Domino(4, 6));
            dominos.Add(new Domino(1, 5));
            dominos.Add(new Domino(6, 7));
            dominos.Add(new Domino(2, 4));
            dominos.Add(new Domino(7, 1));
            return dominos;
        }

        static List<Domino> GetDominos(int count)
        {
            List<Domino> dominos = new List<Domino>(count);
            for (int i = 0; i < count; i++)
            {
                dominos.Add(new Domino());
            }
            return dominos;
        }
    }
}
