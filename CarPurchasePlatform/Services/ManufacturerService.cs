using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _repository;

        public ManufacturerService(IManufacturerRepository repository)
        {
            _repository = repository;
        }

        public Task<Response<IEnumerable<Manufacturer>>> GetAsync()
        {
            return _repository.GetAsync();
        }
    }
}
