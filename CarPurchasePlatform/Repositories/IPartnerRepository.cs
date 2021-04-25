using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public interface IPartnerRepository
    {
        Task<Response<IEnumerable<Partner>>> GetAsync();
        Task<Response> InsertAsync(Partner partner);
        Task<Response> UpdateAsync(Partner partner);
        Task<Response> DeleteAsync(Partner partner);
    }
}
