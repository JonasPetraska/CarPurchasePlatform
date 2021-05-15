using AutopliusServiceSample.Models;
using AutopliusServiceSample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopliusServiceSample.Services
{
    public class DefaultListingService : IListingService
    {
        private readonly IListingRepository _repository;
        public DefaultListingService(IListingRepository repository)
        {
            _repository = repository;
        }

        public Task<Listing> GetAsync(string manufacturer, string model, int year)
        {
            return _repository.GetAsync(manufacturer, model, year);
        }
    }
}
