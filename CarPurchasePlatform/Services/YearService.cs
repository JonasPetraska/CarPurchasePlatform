using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class YearService : IYearService
    {
        private readonly IYearRepository _repository;

        public YearService(IYearRepository repository)
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
