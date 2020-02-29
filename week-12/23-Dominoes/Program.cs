using System;
using System.Collections.Generic;

namespace _23_Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            DominoSet dominos1 = new DominoSet();
            Console.WriteLine("\nGenerated List:");
            Console.WriteLine(dominos1);
            
            dominos1.Sort();
            Console.WriteLine("\nSorted List:");
            Console.WriteLine(dominos1);
            
            dominos1.Sort(true);
            Console.WriteLine("\nSorted List (with rotation):");
            Console.WriteLine(dominos1);

            DominoSet dominos2 = new DominoSet(false);
            Console.WriteLine("\nGenerated List:");
            Console.WriteLine(dominos2);
            dominos2.ChainDominos(out DominoSet chainOk, out DominoSet chainNotOk);
            Console.WriteLine("\nConnected Pieces:");
            Console.WriteLine(chainOk);
            Console.WriteLine("\nExtra Pieces:");
            Console.WriteLine(chainNotOk);

        }
    }
}
