using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public interface IModelRepository
    {
        Task<Response<IEnumerable<Model>>> GetAsync();
        Task<Response<IEnumerable<Model>>> GetAsync(string manufacturer);
    }
}
