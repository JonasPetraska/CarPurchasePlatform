using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IManufacturerService
    {
        Task<Response<IEnumerable<Manufacturer>>> GetAsync();
    }
}
