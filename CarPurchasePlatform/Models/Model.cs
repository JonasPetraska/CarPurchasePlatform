using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class Model
    {
        public Model(string name, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }
    }
}
