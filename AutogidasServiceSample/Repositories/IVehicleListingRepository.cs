using AutogidasServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutogidasServiceSample.Repositories
{
    public interface IVehicleListingRepository
    {
        Task<IEnumerable<VehicleListing>> GetAsync();
        Task<VehicleListing> GetAsync(string manufacturer, string model, int year);
    }
}
