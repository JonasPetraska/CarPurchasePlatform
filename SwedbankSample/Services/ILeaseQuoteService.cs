using SwedbankSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedbankSample.Services
{
    public interface ILeaseQuoteService
    {
        Task<LeaseQuote> CalculateQuote(string personalCode, double price, int period, int initialDepositPercentage, int leftOverPercentage);
    }
}
