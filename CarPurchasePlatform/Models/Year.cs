using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class Year
    {
        public Year(int value, string manufacturer, string model)
        {
            Value = value;
            Manufacturer = manufacturer;
            Model = model;
        }

        [Key]
        public int Id { get; set; }

        public int Value { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}
