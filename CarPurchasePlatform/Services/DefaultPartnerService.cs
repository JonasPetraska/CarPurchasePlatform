using CarPurchasePlatform.Models;
using CarPurchasePlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultPartnerService : IPartnerService
    {
        private readonly IPartnerRepository _repository;

        public DefaultPartnerService(IPartnerRepository repository)
        {
            _repository = repository;
        }

        public Task<Response> DeleteAsync(Partner partner)
        {
            return _repository.DeleteAsync(partner);
        }

        public Task<Response<IEnumerable<Partner>>> GetAsync()
        {
            return _repository.GetAsync();
        }

        public Task<Response> InsertAsync(Partner partner)
        {
            return _repository.InsertAsync(partner);
        }

        public Task<Response> UpdateAsync(Partner partner)
        {
            return _repository.UpdateAsync(partner);
        }
    }
}
