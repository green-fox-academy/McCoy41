using System;

namespace _06_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            // IntroduceYourself
            string name = "Karel Komárek";
            int age = 28;
            double height_m = 1.85;

            Console.WriteLine("INTRODUCTION");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height: " + height_m + " m");

            // TwoNumbers
            Console.WriteLine("\nTWO NUMBERS");
            Console.WriteLine(22 + 13);
            Console.WriteLine(22 - 13);
            Console.WriteLine(22 * 13);
            Console.WriteLine(22 / 13.0);
            Console.WriteLine(22 / 13);
            Console.WriteLine(22 % 13);

            //CodingHours
            int weeks = 17;
            int days = 5;
            int hours = 6;
            double avg = 56.0;

            Console.WriteLine("\nCODING HOURS");
            Console.WriteLine("Total hours of coding: " + hours * days * weeks);
            Console.WriteLine("Percentage of coding hours: {0:0.00}%", hours * days / avg * 100);
        }
    }
}
