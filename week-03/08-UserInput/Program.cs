using System;

namespace _08_UserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            double miles;
            double km;
            
            // HelloUser
            Console.WriteLine("Hello! To be more friendly, what's your name?");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "! Welcome to mileage conversion tool!");
            
            // MileToKmConverter
            Console.Write("Specify the distance in miles: ");
            miles = Convert.ToDouble(Console.ReadLine());
            km = miles * 1.609344;
            Console.WriteLine(miles + " miles equals to (approximately) {0:0.000} km.", km);
        }
    }
}
