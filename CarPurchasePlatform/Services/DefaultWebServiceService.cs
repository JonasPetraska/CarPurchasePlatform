using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultWebServiceService : IWebServiceService
    {
        private readonly IWebServiceRepository _repository;

        public DefaultWebServiceService(IWebServiceRepository repository)
        {
            _repository = repository;
        }

        public Task<Response> DeleteAsync(WebService partner)
        {
            return _repository.DeleteAsync(partner);
        }

        public Task<Response<IEnumerable<WebService>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<Response<IEnumerable<WebServiceQoS>>> GetQoSParametersAsync()
        {
            return _repository.GetQoSParametersAsync();
        }

        public Task<Response<IEnumerable<WebServiceQoS>>> GetQoSParametersAsync(WebServiceTypeEnum WebServiceType)
        {
            return _repository.GetQoSParametersAsync(WebServiceType);
        }

        public Task<Response> InsertAsync(WebService partner)
        {
            return _repository.InsertAsync(partner);
        }

        public Task<Response> UpdateAsync(WebService partner)
        {
            return _repository.UpdateAsync(partner);
        }
    }
}
