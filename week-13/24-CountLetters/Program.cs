using System;
using System.Collections.Generic;

namespace _24_CountLetters
{
    // To make stuff work, I had to add following to .csproj file in <PropertyGroup>
    // <GenerateProgramFile>false</GenerateProgramFile>

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert string (or sentence) to process:");
            string input = Console.ReadLine().Replace(" ", "").ToUpper();

            Console.WriteLine(ToString(CountLetters(input)));
        }

        public static string ToString(Dictionary<char, uint> input)
        {
            string output = "";

            foreach (var item in input)
            {
                output += $" {item.Key} | {item.Value} occurence(s)\n";
            }
            return output;
        }

        public static Dictionary<char, uint> CountLetters(string input)
        {
            input = Sort(input.ToUpper().Replace(" ", ""));
            var output = new Dictionary<char, uint>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!output.ContainsKey(input[i]))
                {
                    output.Add(input[i], 1);
                }
                else output[input[i]]++;
            }
            return output;
        }

        public static string Sort(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
