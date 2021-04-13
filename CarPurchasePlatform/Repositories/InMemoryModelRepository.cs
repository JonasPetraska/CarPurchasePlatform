using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public class InMemoryModelRepository : IModelRepository
    {
        public Task<Response<IEnumerable<Model>>> GetAsync()
        {
            return Task.FromResult(new Response<IEnumerable<Model>>(new List<Model>()
                   {
                        new Model("A1", "Audi"),
                        new Model("A2", "Audi"),
                        new Model("A6", "Audi"),
                        new Model("A7", "Audi"),
                        new Model("A8", "Audi"),
                        new Model("Q5", "Audi"),
                        new Model("Q7", "Audi"),
                        new Model("M1", "BMW"),
                        new Model("M2", "BMW"),
                        new Model("M4", "BMW"),
                        new Model("X1", "BMW"),
                        new Model("X5", "BMW"),
                        new Model("S2000", "Honda"),
                        new Model("Accord", "Honda"),
                        new Model("NSX", "Honda"),
                        new Model("Jazz", "Honda"),
                        new Model("Civic", "Honda"),
                        new Model("Golf", "Volkswagen"),
                        new Model("Passat", "Volkswagen"),
                        new Model("Pantheon", "Volkswagen"),
                        new Model("Caddy", "Volkswagen"),
                        new Model("Polo", "Volkswagen")
                   }));
        }

        public Task<Response<IEnumerable<Model>>> GetAsync(string manufacturer)
        {
            return GetAsync().ContinueWith((result) =>
            {
                var response = result.Result;
                if (response.ResponseType == ErrorTypeEnum.Success)
                    return new Response<IEnumerable<Model>>(response.Content.Where(x => x.Manufacturer == manufacturer).ToList());

                return new Response<IEnumerable<Model>>(response.ErrorMessage, response.ResponseType);
            });
        }
    }
}
