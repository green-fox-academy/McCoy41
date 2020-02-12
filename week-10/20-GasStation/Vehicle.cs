using System;
using System.Collections.Generic;

namespace _20_GasStation
{
    public enum VehicleType { Car, SportsCar, SUV, Bike, Truck, Cistern }
    

    abstract public class Vehicle
    {
        protected string VehicleColor;
        protected string Manufacturer;
        protected string Model;
        protected int FuelConsumption;
        FuelReservoir FuelTank;
    }

    public class Car : Vehicle
    {
        private enum Companies { Skoda, Ford, Hyundai, Honda, Mazda, Dodge, Mercedes, Audi, Volkswagen }
        /*
        protected virtual string GetManufacturer(Companies manufacturer)
        {
            for (int i = 0; i < Enum.GetValues(Companies).Length; i++)
            {

            }
            return "blerk";
        }*/
    }
}
