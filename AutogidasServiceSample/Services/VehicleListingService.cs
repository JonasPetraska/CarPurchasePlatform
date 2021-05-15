using AutogidasServiceSample.Models;
using AutogidasServiceSample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutogidasServiceSample.Services
{
    public class VehicleListingService : IVehicleListingService
    {
        private readonly IVehicleListingRepository _repository;
        public VehicleListingService(IVehicleListingRepository repository)
        {
            _repository = repository;
        }

        public Task<VehicleListing> GetAsync(string manufacturer, string model, int year)
        {
            return _repository.GetAsync(manufacturer, model, year);
        }
    }
}
