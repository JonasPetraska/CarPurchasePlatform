using BTASample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTASample.Services
{
    public class DefaultInsuranceQuoteService : IInsuranceQuoteService
    {
        public Task<InsuranceQuote> Quote(string personalCode, string licensePlate)
        {
            //Simulate calculating insurance quote
            var quote = new InsuranceQuote();
            quote.PersonalCode = personalCode;
            quote.LicensePlate = licensePlate;

            var random = new Random();
            quote.YearlyFee = random.Next(1, 3) * random.Next(80, 300);
            quote.CascoYearlyFee = Math.Round(quote.YearlyFee * random.Next(2, 3), 2);
            quote.GreenCardIncluded = random.Next(0, 100) > 50 ? true : false;
            quote.ProvidesRoadHelp = random.Next(0, 100) < 50 ? true : false;

            return Task.FromResult(quote);
        }
    }
}
