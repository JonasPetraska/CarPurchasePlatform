using AutopliusServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopliusServiceSample.Services
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetAsync(string manufacturer, string model, int year);
    }
}
