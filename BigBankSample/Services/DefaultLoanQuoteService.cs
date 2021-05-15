using BigBankSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBankSample.Services
{
    public class DefaultLoanQuoteService : ILoanQuoteService
    {
        public Task<LoanQuote> ProduceQuoteAsync(string personalCode, double price, int maxLoanPercentage)
        {
            //Simulate calculating a loan
            var quote = new LoanQuote();
            quote.PersonalCode = personalCode;
            quote.Price = price;
            quote.MaxLoanPercentage = maxLoanPercentage;

            var random = new Random();
            quote.TimeInYears = random.Next(1, 7);
            quote.YearlyPercentageFee = random.Next(5, maxLoanPercentage);
            var yearlyFee = Math.Round((((double)quote.YearlyPercentageFee / 100) * (quote.Price / quote.TimeInYears)) + (quote.Price / quote.TimeInYears), 2);

            quote.LoanMonthlyFee = Math.Round(yearlyFee / 12, 2);


            return Task.FromResult(quote);
        }
    }
}
