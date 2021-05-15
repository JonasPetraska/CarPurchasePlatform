using BTASample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTASample.Services
{
    public interface IInsuranceQuoteService
    {
        Task<InsuranceQuote> Quote(string personalCode, string licensePlate);
    }
}
