using System;

namespace _13_TextModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TextMod: ");
            Console.WriteLine("\nFollowing operations are currently available for use:\n\n" +
                              " A - anagram\n" +
                              " M - mirroring\n" +
                              " P - palindrome\n" +
                              " S - sort\n");
            Console.WriteLine("Press <ENTER> for help");
            Console.WriteLine("Press <ESC> to exit the program\n");

            while (true)
            {
                Console.Write("Please select the operation you would like to perform: ");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) break;
                switch (key)
                {
                    case ConsoleKey.M:
                        PrintOut(Mirror(UserInput("mirror")), "mirroring");
                        break;
                    case ConsoleKey.P:
                        PrintOut(Palindrome(UserInput("palindrome")), "palindrome operation");
                        break;
                    case ConsoleKey.S:
                        PrintOut(Sort(SameSizeCheck(UserInput("sorted"), false)), "sorting");
                        break;
                    case ConsoleKey.A:
                        PrintOut(Anagram(UserInput("anagram"), UserInput("anagram")), "anagram comparison");
                        break;
                    case ConsoleKey.Enter:
                        Help("menu");
                        break;
                    default:
                        Console.WriteLine("\nUnknown function!");
                        break;
                }
            }
        }

        static void PrintOut(string input, string oper)
        {
            Console.Write("The result of " + oper + " is: ");
            Console.WriteLine(input + "\n");
        }

        static string UserInput(string type)
        {
            string output;
            do
            {
                if (type == "anagram") Console.WriteLine("\nPlease provide the word that should be compared:");
                else Console.WriteLine("\nPlease provide the word that you would like to turn to " + type + " word:");
                Console.WriteLine("// press <ENTER> for help");
                output = Console.ReadLine();
                if (output == "") Help(type);
            } while (output == "");
            return output;
        }

        static string SameSizeCheck(string input, bool required)
        {
            if (required == true) return input.ToUpper();
            Console.Write("Would you like to make the input same case (CAPITALS)? (Y/N):");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                return input.ToUpper();
            }
            else
            {
                Console.WriteLine();
                return input;
            }
        }
        static string Mirror(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                output += input[^(i+1)];
            }
            return output;
        }       
        
        static string Palindrome(string input)
        {
            string output = input;
            for (int i = 1; i < input.Length; i++)
            {
                output += input[^(i+1)];
            }
            return output;
        }

        static string Sort(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            string output = new string(chars);
            return output;
        }
        static string Anagram(string input1, string input2)
        {
            string output;
            if (Sort(SameSizeCheck(input1, true)).Trim() == Sort(SameSizeCheck(input2, true)).Trim()) output = "TRUE";
            else output = "FALSE";
            Console.WriteLine("\nCompared words were:");
            Console.WriteLine("Input 1: " + input1 + " -> " + SameSizeCheck(input1, true) + " -> " + Sort(SameSizeCheck(input1, true)).Trim());
            Console.WriteLine("Input 2: " + input2 + " -> " + SameSizeCheck(input2, true) + " -> " + Sort(SameSizeCheck(input2, true)).Trim());
            Console.WriteLine();
            return output;
        }
        static void Help(string casename)
        {
            switch (casename)
            {
                case "mirror":
                    Console.WriteLine("This function will take the number, word or sentence and return the same in reversed order.");
                    Console.WriteLine("Example: MIRROR -> RORRIM");
                    break;
                case "palindrome":
                    Console.WriteLine("This function will make the palindrome from the number, word or sentence");
                    Console.WriteLine("Palindrome = number, word or sentence that reads the same from both ends.");
                    Console.WriteLine("Example: PALINDROME -> PALINDROMEMORDNILAP");
                    break;
                case "menu":
                    Console.WriteLine("After selecting the function, you will be asked to provide input.");
                    Console.WriteLine("The description of the functions can be displayed by pressing <ENTER> after selecting the function.\n");
                    break;
                case "sorted":
                    Console.WriteLine("This function will sort the letters / numbers based on the Unicode table from smallest to largest.");
                    Console.WriteLine("Examples: SORT -> ORST; sorT -> Tors\n");
                    break;
                case "anagram":
                    Console.WriteLine("This function compares two numbers, words or sentences, if they are anagrams to each other.");
                    Console.WriteLine("Anagram = number, word or sentence, that has same amount of same characters present.");
                    Console.WriteLine("Examples: ANAGRAM vs GRAMANA = TRUE; ANAGRAM vs MANGO = FALSE");
                    break;
                default:
                    Console.WriteLine("No help is available at the moment.");
                    break;
            }
        }
    }
}
