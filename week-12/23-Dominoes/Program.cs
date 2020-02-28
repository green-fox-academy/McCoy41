using System;
using System.Collections.Generic;

namespace _23_Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            DominoSet dominos = new DominoSet();
            Console.WriteLine("\nGenerated List:");
            Console.WriteLine(dominos);
            
            dominos.Sort();
            Console.WriteLine("\nSorted List:");
            Console.WriteLine(dominos);
            
            dominos.Sort(true);
            Console.WriteLine("\nSorted List (with rotation):");
            Console.WriteLine(dominos);

        }
    }
}
