using System;
using System.Collections.Generic;

namespace _25_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Specify lenght of the Fibonacci Sequence (positive number): ");
            uint length;
            try
            {
                length = Convert.ToUInt32(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                length = 10;
                Console.WriteLine("Invalid input - default length 10 has been selected!");
            }

            var fibSequence = new List<uint>();
            Sequence(length, ref fibSequence);
            Console.WriteLine(ToString(fibSequence));
        }

        public static uint Fibonacci(uint n)
        {
            //Fibonacci(n) = Fibonacci(n-1) + Fibonacci(n-2)
            if (n == 0) return 0;
            else if (n == 1) return 1;
            else return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void Sequence(uint length, ref List<uint> output)
        {
            output.Insert(0,Fibonacci(length));
            if (length != 0) Sequence(length - 1, ref output);
        }

        public static string ToString(List<uint> input)
        {
            string output = "";
            for (int i = 0; i < input.Count; i++)
            {
                output += $"{input[i]}\n";
            }
            return output;
        }
    }
}
