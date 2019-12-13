using System;

namespace _09_Bmi
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight;
            double height;
            double bmi;

            Console.WriteLine("Hello to BMI Calculator!");
            Console.Write("Please input your height (in meters): ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input your weight (in kilograms): ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nInputted Values: " + height + "m, " + weight + "kg.");
            bmi = weight / (height * height);
            Console.WriteLine("\nYour BMI Index is: {0:0.0}", bmi);
            Console.WriteLine("\nFollowing table specifies your level of fatness:\n" +
                              "<18: skelly\n" +
                              "18 - 22,9: skinny \n" + 
                              "23 - 24,9: pretty normal\n" +
                              "25 - 29,9: big\n" +
                              "30 - 34,9: healthy\n" +
                              "35 - 39,9: husky\n" +
                              "40 - 44,9: fluffy\n" +
                              ">50: DAYUM!");
        }
    }
}
