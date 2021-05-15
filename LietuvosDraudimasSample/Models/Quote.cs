using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LietuvosDraudimasSample.Models
{
    public class Quote
    {
        public string PersonalCode { get; set; }
        public string LicensePlate { get; set; }
        public double YearlyFee { get; set; }

        public double CascoYearlyFee { get; set; }
        public bool InsuranceFromWaterDamage { get; set; }
        public bool InsuranceFromDomesticDamage { get; set; }
        public double Francize { get; set; }
    }
}
