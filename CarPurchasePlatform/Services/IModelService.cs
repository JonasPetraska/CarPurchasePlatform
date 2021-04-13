using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IModelService
    {
        Task<Response<IEnumerable<Model>>> GetAsync();
        Task<Response<IEnumerable<Model>>> GetAsync(string manufacturer);
    }
}
