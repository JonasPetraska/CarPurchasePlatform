using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public interface IPartnerSchemaRepository
    {
        Task<Response<IEnumerable<PartnerSchema>>> GetAsync();
        Task<Response<PartnerSchema>> GetAsync(PartnerTypeEnum type);
    }
}
