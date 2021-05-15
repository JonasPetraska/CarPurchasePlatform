using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public interface IWebServiceSchemaRepository
    {
        Task<Response<IEnumerable<WebServiceSchema>>> GetAsync();
        Task<Response<WebServiceSchema>> GetAsync(WebServiceTypeEnum type);
    }
}
