using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutogidasServiceSample.Models
{
    public class VehicleListing
    {
        public VehicleListing(string manufacturer, string model, int year, string vin, string colour,
                              int mileage, double price, string fuelType, bool hasInsurance, 
                              string type, string countryISO2, string licensePlate)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            VIN = vin;
            Colour = colour;
            Mileage = mileage;
            Price = price;
            FuelType = fuelType;
            Type = type;
            HasInsurance = hasInsurance;
            CountryISO2 = countryISO2;
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
        public string Type { get; set; }
        public bool HasInsurance { get; set; }
        public string CountryISO2 { get; set; }
        public string LicensePlate { get; set; }
    }
}
