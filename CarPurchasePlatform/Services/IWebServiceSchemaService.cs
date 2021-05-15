using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IWebServiceSchemaService
    {
        Task<Response<IEnumerable<WebServiceSchema>>> GetAsync();
        Task<Response<WebServiceSchema>> GetAsync(WebServiceTypeEnum type);
    }
}
