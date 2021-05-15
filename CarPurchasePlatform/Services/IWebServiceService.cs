using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IWebServiceService
    {
        Task<Response<IEnumerable<WebService>>> GetAsync();
        Task<Response<IEnumerable<WebServiceQoS>>> GetQoSParametersAsync();
        Task<Response<IEnumerable<WebServiceQoS>>> GetQoSParametersAsync(WebServiceTypeEnum WebServiceType);
        Task<Response> InsertAsync(WebService partner);
        Task<Response> UpdateAsync(WebService partner);
        Task<Response> DeleteAsync(WebService partner);
    }
}
