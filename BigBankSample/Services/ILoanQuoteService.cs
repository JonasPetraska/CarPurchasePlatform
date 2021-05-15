using BigBankSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBankSample.Services
{
    public interface ILoanQuoteService
    {
        Task<LoanQuote> ProduceQuoteAsync(string personalCode, double price, int maxLoanPercentage);
    }
}
