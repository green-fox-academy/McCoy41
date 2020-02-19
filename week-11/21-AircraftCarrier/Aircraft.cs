using System;
using System.Collections.Generic;
using System.Text;

namespace _21_AircraftCarrier
{
    abstract class Aircraft
    {
        public enum AircraftType { F16, F35 }
        public int MaxAmmo { get; protected set; }
        public int CurrentAmmo { get; set; }
        public int BaseDamage { get; protected set; }
        protected string Model { get; set; }
        public AircraftType Type;

        public Aircraft()
        {
            CurrentAmmo = 0;
        }

        public int Fight(int ammoUse = 0)
        {
            if (ammoUse <= 0 || ammoUse > CurrentAmmo)
            {
                ammoUse = CurrentAmmo;
            }
            CurrentAmmo -= ammoUse;
            return ammoUse * BaseDamage;

        }

        public void Refill(int amount = 0)
        {
            if (amount <= 0 || amount + CurrentAmmo > MaxAmmo)
            {
                amount = MaxAmmo - CurrentAmmo;
            }
            CurrentAmmo = amount;
        }

        public string GetType(Aircraft aircraft)
        {
            return aircraft.Model;
        }

        public string GetStatus(Aircraft aircraft)
        {
            return $"Type {GetType(aircraft)}, Ammo: {aircraft.CurrentAmmo}/{aircraft.MaxAmmo}, " +
                   $"Base Damage: {aircraft.BaseDamage}, Max Damage: {aircraft.CurrentAmmo * aircraft.BaseDamage}";
        }

        abstract public bool IsPriority();
    }

    class F16 : Aircraft
    {
        public F16()
        {
            Type = AircraftType.F16;
            MaxAmmo = 8;
            BaseDamage = 30;
            Model = Type.ToString();
        }

        override public bool IsPriority()
        {
            return false;
        }
    }
    
    class F35 : Aircraft
    {
        public F35()
        {
            Type = AircraftType.F35;
            MaxAmmo = 12;
            BaseDamage = 50;
            Model = Type.ToString();
        }

        override public bool IsPriority()
        {
            return true;
        }
    }
}
