using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultPartnerSchemaService : IPartnerSchemaService
    {
        private readonly IPartnerSchemaRepository _repository;
        public DefaultPartnerSchemaService(IPartnerSchemaRepository repository)
        {
            _repository = repository;
        }


        public Task<Response<IEnumerable<PartnerSchema>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<Response<PartnerSchema>> GetAsync(PartnerTypeEnum type)
        {
            return _repository.GetAsync(type);
        }
    }
}
