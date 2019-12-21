using System;

namespace _12_DrawShape
{
    class Program
    {
        // CHARACTERS
        const string w = "\u2588\u2588";
        const string g = "\u2591\u2591";
        const string b = "  ";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Shaper!");

            Console.WriteLine("\nFollowing shapes are available:\n\n" +
                              " C - chessboard\n" +
                              " S - square\n" +
                              " D - diagonal\n" +
                              " X - cross\n" +
                              " T - triangle\n" +
                              " I - diamond\n");
            Console.WriteLine("\n// press <ESC> to exit the program //");

            //TESTING PURPOSES!!!
            while (true)
            {
                Console.Write("\nSelect the shape that should be displayed: ");
                ConsoleKey key = Console.ReadKey().Key;
                if (EscCheck(key) == true) break;
                switch (key)
                {
                    case ConsoleKey.C:
                        Console.WriteLine(" // CHESSBOARD SELECTED");
                        PrintOut(ChessBoard(LenghtPrompt(), null));
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine(" // SQUARE SELECTED");
                        PrintOut(Square(LenghtPrompt(), null));
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine(" // DIAGONAL SELECTED");
                        PrintOut(Diagonal(LenghtPrompt(), null));
                        break;
                    case ConsoleKey.X:
                        Console.WriteLine(" // CROSS SELECTED");
                        PrintOut(Cross(LenghtPrompt(), null));
                        break;
                    case ConsoleKey.T:
                        Console.WriteLine(" // TRIANGLE SELECTED");
                        PrintOut(Triangle(LenghtPrompt(), null));
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine(" // DIAMOND SELECTED");
                        PrintOut(Diamond(LenghtPrompt(), null));
                        break;
                    default:
                        Console.WriteLine(" // INVALID ENTRY");
                        break;
                }
            }
            /*
            while (true)
            {
                Console.Write("\nWould you like to print layered shape? (Y/N): ");
                ConsoleKey key = Console.ReadKey().Key;
                if (EscCheck(key) == true) break;
                switch (key)
                {
                    case ConsoleKey.N:
                        PrintOut(SingleShape());
                        break;
                    case ConsoleKey.Y:
                        break;
                    default:
                        Console.WriteLine(" // please answer Y (yes) or N (no)");
                        break;
                }
            }
        }

        static string[,] SingleShape()
        {
            Console.Write("\nSelect the shape that should be displayed: ");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.C:
                    Console.WriteLine(" // CHESSBOARD SELECTED");
                    return ChessBoard(LenghtPrompt(), null);
                case ConsoleKey.S:
                    Console.WriteLine(" // SQUARE SELECTED");
                    return Square(LenghtPrompt(), null);
                case ConsoleKey.D:
                    Console.WriteLine(" // DIAGONAL SELECTED");
                    return Diagonal(LenghtPrompt(), null);
                case ConsoleKey.X:
                    Console.WriteLine(" // CROSS SELECTED");
                    return Cross(LenghtPrompt(), null);
                case ConsoleKey.T:
                    Console.WriteLine(" // TRIANGLE SELECTED");
                    return Triangle(LenghtPrompt(), null);
                default:
                    Console.WriteLine(" // INVALID ENTRY");
                    return null;
            }
        }
        */
            static string[,] ChessBoard(int length, string[,] input)
            {
                string[,] output;
                if (input != null)
                {
                    output = input;
                }
                else
                {
                    output = new string[length, length];
                    for (int i = 0; i < length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            for (int j = 0; j < length; j++)
                            {
                                if (j % 2 == 1) output[i, j] = b;
                                else output[i, j] = w;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < length; j++)
                            {
                                if (j % 2 == 1) output[i, j] = w;
                                else output[i, j] = b;
                            }
                        }

                    }
                }
                return output;
            }

            static string[,] Square(int length, string[,] input)
            {
                string[,] output;
                if (input != null)
                {
                    output = input;
                }
                else
                {
                    output = new string[length, length];
                    for (int i = 0; i < length; i++)
                    {
                        if (i == 0 || i == length - 1)
                        {

                            for (int j = 0; j < length; j++) output[i, j] = w;
                        }
                        else
                        {
                            for (int j = 0; j < length; j++)
                            {
                                if (j == 0 || j == length - 1) output[i, j] = w;
                                else output[i, j] = b;
                            }
                        }
                    }
                }
                return output;
            }

            static string[,] Diagonal(int length, string[,] input)
            {
                string[,] output;
                Console.Write("From which side should the diagonal start? (L/R): ");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.L:
                        Console.WriteLine(" // LEFT");
                        if (input != null)
                        {
                            output = input;
                        }
                        else
                        {
                            output = new string[length, length];
                            for (int i = 0; i < length; i++)
                            {
                                for (int j = 0; j < length; j++)
                                {
                                    if (i == j) output[i, j] = w;
                                    else output[i, j] = b;
                                }
                            }
                        }
                        return output;
                    case ConsoleKey.R:
                        Console.WriteLine(" // RIGHT");
                        if (input != null)
                        {
                            output = input;
                        }
                        else
                        {
                            output = new string[length, length];
                            for (int i = 0; i < length; i++)
                            {
                                for (int j = 0; j < length; j++)
                                {
                                    if (i == (length - 1) - j) output[i, j] = w;
                                    else output[i, j] = b;
                                }
                            }
                        }
                        return output;
                    default:
                        Console.WriteLine(" // INVALID ENTRY");
                        return null;
                }
            }

            static string[,] Cross(int length, string[,] input)
            {
                string[,] output;
                if (input != null)
                {
                    output = input;
                }
                else
                {
                    output = new string[length, length];
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (i == j || i == (length - 1) - j) output[i, j] = w;
                            else output[i, j] = b;
                        }
                    }
                }
                return output;
            }

            static string[,] Triangle(int length, string[,] input)
            {
                string[,] output;
                Console.WriteLine("\nAvailable corners:\n" +
                                  " 1 - Top-Left corner\n" +
                                  " 2 - Top-Right corner\n" +
                                  " 3 - Bottom-Left corner\n" +
                                  " 4 - Bottom-Right corner");
                Console.Write("Select the corner: ");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine(" // TOP-LEFT");
                        if (input != null)
                        {
                            output = input;
                        }
                        else
                        {
                            output = new string[length, length];
                            for (int i = 0; i < length; i++)
                            {
                                for (int j = 0; j < length; j++)
                                {
                                    if (i <= (length - 1) - j) output[i, j] = w;
                                    else output[i, j] = b;
                                }
                            }
                        }
                        return output;
                    case ConsoleKey.NumPad2:
                        Console.WriteLine(" // TOP-RIGHT");
                        if (input != null)
                        {
                            output = input;
                        }
                        else
                        {
                            output = new string[length, length];
                            for (int i = 0; i < length; i++)
                            {
                                for (int j = 0; j < length; j++)
                                {
                                    if (i <= j) output[i, j] = w;
                                    else output[i, j] = b;
                                }
                            }
                        }
                        return output;
                    case ConsoleKey.NumPad3:
                        Console.WriteLine(" // BOTTOM-LEFT");
                        if (input != null)
                        {
                            output = input;
                        }
                        else
                        {
                            output = new string[length, length];
                            for (int i = 0; i < length; i++)
                            {
                                for (int j = 0; j < length; j++)
                                {
                                    if (i >= j) output[i, j] = w;
                                    else output[i, j] = b;
                                }
                            }
                        }
                        return output;
                    case ConsoleKey.NumPad4:
                        Console.WriteLine(" // BOTTOM-RIGHT");
                        if (input != null)
                        {
                            output = input;
                        }
                        else
                        {
                            output = new string[length, length];
                            for (int i = 0; i < length; i++)
                            {
                                for (int j = 0; j < length; j++)
                                {
                                    if (i >= (length - 1) - j) output[i, j] = w;
                                    else output[i, j] = b;
                                }
                            }
                        }
                        return output;
                    default:
                        Console.WriteLine(" // INVALID ENTRY");
                        return null;
                }
            }

            static string[,] Diamond(int length, string[,] input)
            {
                string[,] output;
                if (input != null)
                {
                    output = input;
                }
                else
                {
                    output = new string[length, length];
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {

                        }
                    }
                }
                return output;
            }

            static int LenghtPrompt()
            {
                Console.Write("Specify size of the shape (number of rows): ");
                return Convert.ToInt32(Console.ReadLine());
            }

            static bool EscCheck(ConsoleKey key)
            {
                if (key == ConsoleKey.Escape) return true;
                else return false;
            }

            static void PrintOut(string[,] input)
            {
                while (input != null)
                {
                    Console.WriteLine();
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        for (int j = 0; j < input.GetLength(1); j++)
                        {
                            Console.Write(input[i, j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                }
            }
        }
    }
}
