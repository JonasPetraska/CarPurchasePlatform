using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IPartnerSchemaService
    {
        Task<Response<IEnumerable<PartnerSchema>>> GetAsync();
        Task<Response<PartnerSchema>> GetAsync(PartnerTypeEnum type);
    }
}
