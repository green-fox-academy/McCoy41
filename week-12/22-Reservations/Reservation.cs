using System;
using System.Collections.Generic;
using System.Text;

namespace _22_Reservations
{
    class Reservation : IReservation
    {
        string ReservationCode { get; set; }
        string DayOfWeek { get; set; }

        public Reservation()
        {
            ReservationCode = GenerateCode(8);
            DayOfWeek = GenerateDow();
        }

        private string GenerateCode(int length)
        {
            Random rndChar = new Random();
            List<char> charList = new List<char>();
            string output = "";

            for (int i = 48; i < 58; i++) // 0-9
            {
                charList.Add(Convert.ToChar(i));
            }

            for (int i = 65; i < 91; i++) // A-Z
            {
                charList.Add(Convert.ToChar(i));
            }

            for (int i = 0; i < length; i++)
            {
                output += charList[rndChar.Next(charList.Count)];
            }

            return output;
        }

        private string GenerateDow()
        {
            string[] day = { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };
            Random rndDay = new Random();
            return day[rndDay.Next(day.Length)];
        }

        public string GetCodeBooking()
        {
            return ReservationCode;
        }

        public string GetDowBooking()
        {
            return DayOfWeek;
        }
    }
}
