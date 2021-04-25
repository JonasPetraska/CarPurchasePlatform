using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultModelService : IModelService
    {
        private readonly IModelRepository _repository;

        public DefaultModelService(IModelRepository repository)
        {
            _repository = repository;
        }

        public Task<Response<IEnumerable<Model>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<Response<IEnumerable<Model>>> GetAsync(string manufacturer)
        {
            return _repository.GetAsync(manufacturer);
        }
    }
}
