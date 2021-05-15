using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedbankSample.Models
{
    public class LeaseQuote
    {
        public string PersonalCode { get; set; }
        public double Price { get; set; }
        public int InitialDepositPercentage { get; set; }
        public int Period { get; set; }
        public int LeftOverPercentage { get; set; }

        public double LeaseMonthlyFee { get; set; }
        public double InitialFee { get; set; }
        public double LeftOver { get; set; }
    }
}
