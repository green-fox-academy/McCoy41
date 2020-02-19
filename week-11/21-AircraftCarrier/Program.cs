using System;

namespace _21_AircraftCarrier
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrier carrier1 = new Carrier(8);
            Console.WriteLine(carrier1.GetStatus(carrier1));
        }
    }
}
