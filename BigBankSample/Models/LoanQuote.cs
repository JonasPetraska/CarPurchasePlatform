using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBankSample.Models
{
    public class LoanQuote
    {
        public string PersonalCode { get; set; }
        public double Price { get; set; }
        public int MaxLoanPercentage { get; set; }

        public double LoanMonthlyFee { get; set; }
        public int YearlyPercentageFee { get; set; }
        public int TimeInYears { get; set; }
    }
}
