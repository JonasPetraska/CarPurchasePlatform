using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTASample.Models
{
    public class InsuranceQuote
    {
        public string PersonalCode { get; set; }
        public string LicensePlate { get; set; }
        public double YearlyFee { get; set; }

        public double CascoYearlyFee { get; set; }
        public bool ProvidesRoadHelp { get; set; }
        public bool GreenCardIncluded { get; set; }
    }
}
