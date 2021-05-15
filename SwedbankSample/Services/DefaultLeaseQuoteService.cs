using SwedbankSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedbankSample.Services
{
    public class DefaultLeaseQuoteService : ILeaseQuoteService
    {
        public Task<LeaseQuote> CalculateQuote(string personalCode, double price, int period, int initialDepositPercentage, int leftOverPercentage)
        {
            //Simulate calculating lease quote
            var quote = new LeaseQuote();
            quote.Period = period;
            quote.PersonalCode = personalCode;
            quote.Price = price;
            quote.InitialDepositPercentage = initialDepositPercentage;
            quote.LeftOverPercentage = leftOverPercentage;

            quote.InitialFee = Math.Round(quote.Price * (quote.InitialDepositPercentage / 100), 2);
            quote.LeftOver = Math.Round(quote.Price * (quote.LeftOverPercentage / 100), 2);
            quote.LeaseMonthlyFee = Math.Round((quote.Price - quote.InitialFee - quote.LeftOver) / (quote.Period * 12), 2);


            return Task.FromResult(quote);
        }
    }
}
