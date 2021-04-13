using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public class InMemoryManufacturerRepository : IManufacturerRepository
    {
        public Task<Response<IEnumerable<Manufacturer>>> GetAsync()
        {
            return Task.FromResult(new Response<IEnumerable<Manufacturer>>(new List<Manufacturer>()
                   {
                        new Manufacturer("Audi"),
                        new Manufacturer("BMW"),
                        new Manufacturer("Honda"),
                        new Manufacturer("Volkswagen")
                   }));
        }
    }
}
