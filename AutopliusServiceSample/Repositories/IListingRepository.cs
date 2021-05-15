using AutopliusServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopliusServiceSample.Repositories
{
    public interface IListingRepository
    {
        Task<IEnumerable<Listing>> GetAsync();
        Task<Listing> GetAsync(string manufacturer, string model, int year);
    }
}
