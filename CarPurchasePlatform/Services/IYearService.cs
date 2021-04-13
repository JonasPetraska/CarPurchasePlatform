using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IYearService
    {
        Task<Response<IEnumerable<Year>>> GetAsync();
        Task<Response<IEnumerable<Year>>> GetAsync(string manufacturer, string model);
    }
}
