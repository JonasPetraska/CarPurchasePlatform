using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopliusServiceSample.Models
{
    public class Listing
    {
        public Listing(string manufacturer, string model, int year, string vin, string colour, 
                       int mileage, double price, string fuelType, int engineSizeCM3, string type,
                       string gearbox, string steeringWheelPosition, string licensePlate)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            VIN = vin;
            Colour = colour;
            Mileage = mileage;
            Price = price;
            FuelType = fuelType;
            EngineSizeCM3 = engineSizeCM3;
            Type = type;
            Gearbox = gearbox;
            SteeringWheelPosition = steeringWheelPosition;
            LicensePlate = licensePlate;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public string FuelType { get; set; }
        public int EngineSizeCM3 { get; set; }
        public string Type { get; set; }
        public string Gearbox { get; set; }
        public string SteeringWheelPosition { get; set; }
        public string LicensePlate { get; set; }
    }
}
