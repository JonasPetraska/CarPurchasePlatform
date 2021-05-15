using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegitraSample.Models
{
    public class RegistrationFeeEstimate
    {
        public string VIN { get; set; } 
        public double RegistrationFee { get; set; }

        public bool AllowedToRegister { get; set; }
    }
}
