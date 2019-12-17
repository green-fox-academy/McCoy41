using System;

namespace _12_DrawShape
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Shaper!");
            string w = "\u2588\u2588";
            string g = "\u2591\u2591";
            string b = "  ";
            int lenght;

            Console.WriteLine("\nFollowing shapes are available:\n\n" +
                              " C - chessboard\n"/* +
                              " D - diagonal\n" +
                              " P - pyramid\n" +
                              " T - triangle\n" +
                              " S - square\n" +
                              " I - diamond\n"*/);
            Console.WriteLine("\n// press <ESC> to exit the program //");

            while (true)
            {
                Console.Write("\nSelect the shape that should be displayed: ");
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.Escape)
                {
                    break;
                }
                switch (key)
                {
                    case ConsoleKey.C:
                        Console.WriteLine("\n// CHESSBOARD SELECTED //");
                        ChessBoard(w, g, LenghtPrompt());
                        break;

                }
            }
        }

        static void ChessBoard(string b, string w, int lenght)
        {
            Console.WriteLine();
            for (int i = 0; i < lenght; i++)
            {
                if (i % 2 == 1)
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        if (j % 2 == 1) Console.Write(b);
                        else Console.Write(w);
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        if (j % 2 == 1) Console.Write(w);
                        else Console.Write(b);
                    }
                    Console.WriteLine();
                }
            }
        }

        static int LenghtPrompt()
        {
            Console.Write("\nSpecify size of the shape (number of rows): ");
            int lenght = Convert.ToInt32(Console.ReadLine());

            return lenght;
        }
    }
}
