using AutogidasServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutogidasServiceSample.Services
{
    public interface IVehicleListingService
    {
        Task<VehicleListing> GetAsync(string manufacturer, string model, int year);
    }
}
