using System;
using System.Collections.Generic;
using System.Text;

namespace _21_AircraftCarrier
{
    class Carrier
    {
        int AmmoStorage { get; set; }
        public int Health { get; set; }
        List<Aircraft> Hangar { get; set; }

        public Carrier(int hangarSize = 0, int ammo = 0, int health = 0)
        {
            if (hangarSize <= 0) hangarSize = 5;
            if (health <= 1000) health = hangarSize * 1000;
            if (ammo <= 100) ammo = hangarSize * 100;

            Health = health;
            AmmoStorage = ammo;
            Hangar = new List<Aircraft>();
            for (int i = 0; i < hangarSize; i++)
            {
                Hangar.Add(Add());
            }
        }

        public Aircraft.AircraftType RandomAircraft()
        {
            Random rnd = new Random();
            var aircrafts = Enum.GetValues(typeof(Aircraft.AircraftType));
            return (Aircraft.AircraftType)rnd.Next(aircrafts.Length);
        }
        public Aircraft Add()
        {
            switch (RandomAircraft())
            {
                case Aircraft.AircraftType.F35:
                    return new F35();
                case Aircraft.AircraftType.F16:
                default:
                    return new F16();
            }
        }

        public string GetStatus(Carrier carrier)
        {
            int dmgTotal = 0;
            string hangar = "";

            foreach (var aircraft in carrier.Hangar)
            {
                dmgTotal += aircraft.BaseDamage * aircraft.CurrentAmmo;
                hangar += aircraft.GetStatus(aircraft) + "\n";
            }
            string status = $"HP: {carrier.Health}, Aircraft count: {carrier.Hangar.Count}, " +
                          $"Ammo Storage: {carrier.AmmoStorage}, Total damage: {dmgTotal}\n" +
                          $"Aircrafts:\n";
            return status + hangar;
        }

        public void Fill(Carrier carrier, int amount = 0)
        {

        }
    }
}
