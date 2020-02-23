using System;
using System.Collections.Generic;

namespace _22_Reservations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Reservation> reservations = new List<Reservation>();
            for (int i = 0; i < 10; i++)
            {
                reservations.Add(new Reservation());
            }

            foreach (Reservation reservation in reservations)
            {
                Console.WriteLine($"Booking# {reservation.GetCodeBooking()} for {reservation.GetDowBooking()}");
            }
        }
    }
}
