using LietuvosDraudimasSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LietuvosDraudimasSample.Services
{
    public interface IQuoteService
    {
        Task<Quote> GetQuoteAsync(string personalCode, string licensePlate);
    }
}
