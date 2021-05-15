using AutopliusServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopliusServiceSample.Repositories
{
    public class InMemoryListingRepository : IListingRepository
    {
        public async Task<Listing> GetAsync(string manufacturer, string model, int year)
        {
            var listings = await GetAsync();
            var allFittingListings = listings.Where(x => x.Manufacturer == manufacturer && x.Model == model && x.Year == year).ToList();
            var minPrice = allFittingListings.Min(x => x.Price);
            return allFittingListings.FirstOrDefault(x => x.Price == minPrice);
        }

        public Task<IEnumerable<Listing>> GetAsync()
        {
            return Task.FromResult<IEnumerable<Listing>>(new List<Listing>()
            {
                new Listing("Audi", "A6", 2010, "3N1CB51D83L786470", "Black", 157894, 8040.80, "Petrol", 2700, "Saloon", "Manual", "Left", "Aud1"),
                new Listing("Audi", "A6", 2011, "JTDZN3EU6E3336988", "Red", 358704, 6500, "Gasoline", 2800, "Saloon", "Manual", "Left", "LRT882"),
                new Listing("Audi", "A6", 2012, "WBAVB17546NK31399", "Purple", 258945, 4578, "Petrol", 2000, "Estate", "Manual", "Left", "KMS221"),

                new Listing("Volkswagen", "Golf", 2006, "1HTMMAAM97H437006", "Yellow", 475869, 1908, "Petrol", 2000, "Hatchback", "Automatic", "Left", "TMS223"),
                new Listing("Volkswagen", "Passat", 2021, "3GNCA33B99S543949", "Green", 120, 47000, "Petrol", 2200, "Saloon", "Manual", "Left", "BMS221"),
                new Listing("Volkswagen", "Caddy", 2015, "WBAVB13536KX41203", "Black", 125000, 7200, "Gasoline", 1800, "Saloon", "Manual", "Left", "KKK333"),
                new Listing("Volkswagen", "Caddy", 2015, "2T1CF22P1YC406999", "White", 145700, 7400, "Petrol", 2000, "Saloon", "Manual", "Left", "MPG221"),

                new Listing("Honda", "Civic", 2017, "5N1MD28T93C661833", "Gray", 157894, 8040.80, "Petrol", 2700, "Saloon", "Manual", "Left", "GGG223"),
                new Listing("Honda", "Accord", 2019, "1GNDS13S942130438", "Gray", 178000, 8250.47, "Gasoline", 2100, "Saloon", "Automatic", "Left", "BBK334"),
                new Listing("Honda", "Accord", 2019, "2T1BR32E35C423628", "Black", 198500, 6500, "Petrol", 2200, "Saloon", "Manual", "Left", "LTU111"),

                new Listing("BMW", "M4", 2014, "2C4GM68404R510793", "Black", 140505, 6000, "Petrol", 2000, "Saloon", "Automatic", "Left", "W0W"),
                new Listing("BMW", "M4", 2014, "1FTZR15X0YTB25082", "Black", 178505, 8000, "Galone", 2300, "Saloon", "Manual", "Left", "C0W"),
                new Listing("BMW", "M4", 2014, "1FDKF37G4VEB87549", "White", 158951, 7685, "Petrol", 3000, "Saloon", "Automatic", "Left", "I2U")
            });
        }
    }
}
