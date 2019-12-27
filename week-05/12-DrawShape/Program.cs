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
                        PrintOut(MultiShape());
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
                    return ChessBoard(LengthPrompt(), null);
                case ConsoleKey.S:
                    Console.WriteLine(" // SQUARE SELECTED");
                    return Square(LengthPrompt(), null);
                case ConsoleKey.D:
                    Console.WriteLine(" // DIAGONAL SELECTED");
                    return Diagonal(LengthPrompt(), null);
                case ConsoleKey.X:
                    Console.WriteLine(" // CROSS SELECTED");
                    return Cross(LengthPrompt(), null);
                case ConsoleKey.T:
                    Console.WriteLine(" // TRIANGLE SELECTED");
                    return Triangle(LengthPrompt(), null);
                case ConsoleKey.I:
                    Console.WriteLine(" // DIAMOND SELECTED");
                    return Diamond(LengthPrompt(), null);
                default:
                    Console.WriteLine(" // INVALID ENTRY");
                    return null;
            }
        }
        
        static string[,] MultiShape()
        {
            string[,] input;
            Console.WriteLine();
            int size = LengthPrompt();
            Console.Write("Select the background shape: ");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.C:
                    Console.WriteLine(" // CHESSBOARD SELECTED");
                    input = ChessBoard(size, null);
                    break;
                case ConsoleKey.S:
                    Console.WriteLine(" // SQUARE SELECTED");
                    input = Square(size, null);
                    break;
                case ConsoleKey.D:
                    Console.WriteLine(" // DIAGONAL SELECTED");
                    input = Diagonal(size, null);
                    break;
                case ConsoleKey.X:
                    Console.WriteLine(" // CROSS SELECTED");
                    input = Cross(size, null);
                    break;
                case ConsoleKey.T:
                    Console.WriteLine(" // TRIANGLE SELECTED");
                    input = Triangle(size, null);
                    break;
                case ConsoleKey.I:
                    Console.WriteLine(" // DIAMOND SELECTED");
                    input = Diamond(size, null);
                    break;
                default:
                    Console.WriteLine(" // INVALID ENTRY");
                    return null;
            }
            Console.Write("Select the foreground shape: ");
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.C:
                    Console.WriteLine(" // CHESSBOARD SELECTED");
                    return ChessBoard(size, TurnToBackground(input));
                case ConsoleKey.S:
                    Console.WriteLine(" // SQUARE SELECTED");
                    return Square(size, TurnToBackground(input));
                case ConsoleKey.D:
                    Console.WriteLine(" // DIAGONAL SELECTED");
                    return Diagonal(size, TurnToBackground(input));
                case ConsoleKey.X:
                    Console.WriteLine(" // CROSS SELECTED");
                    return Cross(size, TurnToBackground(input));
                case ConsoleKey.T:
                    Console.WriteLine(" // TRIANGLE SELECTED");
                    return Triangle(size, TurnToBackground(input));
                case ConsoleKey.I:
                    Console.WriteLine(" // DIAMOND SELECTED");
                    return Diamond(size, TurnToBackground(input));
                default:
                    Console.WriteLine(" // INVALID ENTRY");
                    return null;
            }
        }

        static string[,] ChessBoard(int length, string[,] input)
        {
            string[,] output;
            if (input != null) output = input;
            else output = new string[length, length];
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 1)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (j % 2 == 1) output[i, j] = w;
                        else if (output[i, j] == g) continue;
                        else output[i, j] = b;
                    }
                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (j % 2 == 0) output[i, j] = w;
                        else if (output[i, j] == g) continue;
                        else output[i, j] = b;
                    }
                }
            }
            return output;
        }

        static string[,] Square(int length, string[,] input)
        {
            string[,] output;
            bool fill = FillCheck();
            if (input != null) output = input;
            else output = new string[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (fill == true) output[i, j] = w;
                    else if (i == 0 || i == length - 1 || j == 0 || j == length - 1) output[i, j] = w;
                    else if (output[i, j] == g) continue;
                    else output[i, j] = b;
                }
            }
            return output;
        }

        static string[,] Diagonal(int length, string[,] input)
        {
            string[,] output;
            if (input != null) output = input;
            else output = new string[length, length];
            Console.Write("From which side should the diagonal start? (L/R): ");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.L:
                    Console.WriteLine(" // LEFT");
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (i == j) output[i, j] = w;
                            else if (output[i, j] == g) continue;
                            else output[i, j] = b;
                        }
                    }
                    return output;
                case ConsoleKey.R:
                    Console.WriteLine(" // RIGHT");
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (i == (length - 1) - j) output[i, j] = w;
                            else if (output[i, j] == g) continue;
                            else output[i, j] = b;
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
            if (input != null) output = input;
            else output = new string[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j || i == (length - 1) - j) output[i, j] = w;
                    else if (output[i, j] == g) continue;
                    else output[i, j] = b;
                }
            }
            return output;
        }

        static string[,] Triangle(int length, string[,] input)
        {
            string[,] output;
            if (input != null) output = input;
            else output = new string[length, length];
            bool fill = FillCheck();
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
                case ConsoleKey.D1:
                    Console.WriteLine(" // TOP-LEFT");
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (fill == true && i <= (length - 1) - j) output[i, j] = w;
                            else if (i == 0 || j == 0 || i == (length - 1) - j) output[i, j] = w;
                            else if (output[i, j] == g) continue;
                            else output[i, j] = b;
                        }
                    }
                    return output;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.WriteLine(" // TOP-RIGHT");
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (fill == true && i <= j) output[i, j] = w;
                            else if (i == 0 || j == (length - 1) || i == j) output[i, j] = w;
                            else if (output[i, j] == g) continue;
                            else output[i, j] = b;
                        }
                    }
                    return output;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.WriteLine(" // BOTTOM-LEFT");
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (fill == true && i >= j) output[i, j] = w;
                            else if (i == (length - 1) || j == 0 || i == j) output[i, j] = w;
                            else if (output[i, j] == g) continue;
                            else output[i, j] = b;
                        }
                    }
                    return output;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.WriteLine(" // BOTTOM-RIGHT");
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (fill == true && i >= (length - 1) - j) output[i, j] = w;
                            else if (i == (length - 1) || j == (length - 1) || i == (length - 1) - j) output[i, j] = w;
                            else if (output[i, j] == g) continue;
                            else output[i, j] = b;
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
            //Q1: I from 0 to (len+1)/2 ; J from 0 to (len+1)/2 - bottom right
            //Q2: I from 0 to (len+1)/2 ; J from len/2 to len - bottom left
            //Q3: I from len/2 to len ; J from 0 to (len+1)/2 - top right
            //Q4: I from len/2 to len ; J from len/2 to len - top left

            string[,] output;
            bool fill = FillCheck();
            if (input != null) output = input;
            else output = new string[length, length];
            for (int i = 0; i < (length + 1) / 2; i++)
            {
                for (int j = 0; j < (length + 1) / 2; j++) //Q1
                {
                    if (fill == true && i >= ((length + 1) / 2 - 1) - j) output[i, j] = w;
                    else if (i == ((length + 1) / 2 - 1) - j) output[i, j] = w;
                    else if (output[i, j] == g) continue;
                    else output[i, j] = b;
                }
                for (int j = length / 2; j < length; j++) //Q2
                {
                    if (fill == true && i + (length / 2) >= j) output[i, j] = w;
                    else if (i + (length / 2) == j) output[i, j] = w;
                    else if (output[i, j] == g) continue;
                    else output[i, j] = b;
                }
            }
            for (int i = length / 2; i < length; i++)
            {
                for (int j = 0; j < (length + 1) / 2; j++) //Q3
                {
                    if (fill == true && i - (length / 2) <= j) output[i, j] = w;
                    else if (i - (length / 2) == j) output[i, j] = w;
                    else if (output[i, j] == g) continue;
                    else output[i, j] = b;
                }
                for (int j = length / 2; j < length; j++) //Q4
                {
                    if (fill == true && i - (length / 2) <= (length - 1) - j) output[i, j] = w;
                    else if (i - (length / 2) == (length - 1) - j) output[i, j] = w;
                    else if (output[i, j] == g) continue;
                    else output[i, j] = b;
                }
            }
            return output;
        }
        
        static string[,] TurnToBackground (string[,] input)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == w) input[i, j] = g;
                }
            }
            return input;
        }

        static int LengthPrompt()
        {
            Console.Write("Specify size of the shape (number of rows): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static bool FillCheck()
        {
            Console.Write("Should the shape filled? (Y/N): ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine(" // FILLED");
                return true;
            }
            else
            {
                Console.WriteLine(" // HOLLOW");
                return false;
            }
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
