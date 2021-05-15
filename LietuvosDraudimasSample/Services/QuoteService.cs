using LietuvosDraudimasSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LietuvosDraudimasSample.Services
{
    public class QuoteService : IQuoteService
    {
        public Task<Quote> GetQuoteAsync(string personalCode, string licensePlate)
        {
            //Simulate calculating quote
            var quote = new Quote();
            quote.PersonalCode = personalCode;
            quote.LicensePlate = licensePlate;

            var random = new Random();
            quote.YearlyFee = random.Next(1, 3) * random.Next(100, 500);
            quote.CascoYearlyFee = quote.YearlyFee * random.Next(2, 3);
            quote.InsuranceFromWaterDamage = random.Next(0, 100) > 50 ? true : false;
            quote.InsuranceFromDomesticDamage = random.Next(0, 100) < 50 ? true : false;
            quote.Francize = Math.Round(quote.YearlyFee * random.NextDouble(), 2);

            return Task.FromResult(quote);
        }
    }
}
