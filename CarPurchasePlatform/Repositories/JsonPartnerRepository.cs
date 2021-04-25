using CarPurchasePlatform.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public class JsonPartnerRepository : IPartnerRepository
    {
        public static string PathToFile { get; set; } = "wwwroot/data/partners.json";

        public async Task<Response> DeleteAsync(Partner partner)
        {
            var getResult = await GetAsync();
            if (getResult.ResponseType != ErrorTypeEnum.Success)
                return new Response(true);

            var allEntities = getResult.Content.ToList();
            if (allEntities == null || !allEntities.Any())
                return new Response(false);

            var entity = allEntities.FirstOrDefault(x => x.Id == partner.Id);
            if (entity == null)
                return new Response(false);

            allEntities.Remove(entity);
            File.WriteAllText(PathToFile, JsonConvert.SerializeObject(allEntities));

            return new Response(true);
        }

        public Task<Response<IEnumerable<Partner>>> GetAsync()
        {
            if (File.Exists(PathToFile))
                return Task.FromResult(new Response<IEnumerable<Partner>>(JsonConvert.DeserializeObject<IEnumerable<Partner>>(File.ReadAllText(PathToFile))));
            else
                return Task.FromResult(new Response<IEnumerable<Partner>>(new List<Partner>()));
        }

        public async Task<Response> InsertAsync(Partner partner)
        {
            var getResult = await GetAsync();
            if (getResult.ResponseType != ErrorTypeEnum.Success)
                return new Response(true);

            var allEntities = getResult.Content.ToList();
            if (allEntities.Any(x => x.Id == partner.Id))
                return new Response(false);

            var maxNumber = !allEntities.Any() ? 0 : allEntities.Max(x => x.Id);
            partner.Id = maxNumber + 1;

            allEntities.Add(partner);
            File.WriteAllText(PathToFile, JsonConvert.SerializeObject(allEntities));

            return new Response(true);
        }

        public async Task<Response> UpdateAsync(Partner partner)
        {
            var getResult = await GetAsync();
            if (getResult.ResponseType != ErrorTypeEnum.Success)
                return new Response(true);

            var allEntities = getResult.Content.ToList();
            if (allEntities == null || !allEntities.Any())
                return new Response(false);

            var entity = allEntities.FirstOrDefault(x => x.Id == partner.Id);
            if (entity == null)
                return new Response(false);

            allEntities.Remove(entity);
            allEntities.Add(partner);
            File.WriteAllText(PathToFile, JsonConvert.SerializeObject(allEntities));

            return new Response(true);
        }
    }
}
