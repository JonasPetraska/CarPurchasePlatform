using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public interface IManufacturerRepository
    {
        Task<Response<IEnumerable<Manufacturer>>> GetAsync();
    }
}
