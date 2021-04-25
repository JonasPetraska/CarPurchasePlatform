using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultYearService : IYearService
    {
        private readonly IYearRepository _repository;

        public DefaultYearService(IYearRepository repository)
        {
            _repository = repository;
        }

        public Task<Response<IEnumerable<Year>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<Response<IEnumerable<Year>>> GetAsync(string manufacturer, string model)
        {
            return _repository.GetAsync(manufacturer, model);
        }
    }
}
