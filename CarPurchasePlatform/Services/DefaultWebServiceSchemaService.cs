using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultWebServiceSchemaService : IWebServiceSchemaService
    {
        private readonly IWebServiceSchemaRepository _repository;
        public DefaultWebServiceSchemaService(IWebServiceSchemaRepository repository)
        {
            _repository = repository;
        }


        public Task<Response<IEnumerable<WebServiceSchema>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<Response<WebServiceSchema>> GetAsync(WebServiceTypeEnum type)
        {
            return _repository.GetAsync(type);
        }
    }
}
