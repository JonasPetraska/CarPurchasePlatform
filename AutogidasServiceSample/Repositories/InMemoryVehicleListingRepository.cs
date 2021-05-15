using AutogidasServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutogidasServiceSample.Repositories
{
    public class InMemoryVehicleListingRepository : IVehicleListingRepository
    {
        public async Task<VehicleListing> GetAsync(string manufacturer, string model, int year)
        {
            var listings = await GetAsync();
            return listings.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model && x.Year == year);
        }

        public Task<IEnumerable<VehicleListing>> GetAsync()
        {
            return Task.FromResult<IEnumerable<VehicleListing>>(new List<VehicleListing>()
            {
                new VehicleListing("Audi", "Q5", 2017, "2T1BURHE5EC055199", "Black", 120000, 49000, "Petrol", true, "SUV", "DE", "LTU992"),
                new VehicleListing("Audi", "Q7", 2021, "JTEES41A792119935", "Blue", 230, 85000, "Gasoline", false, "SUV", "DE", "ART221"),
                new VehicleListing("Audi", "Q5", 2019, "4A3AC44G34E057728", "Orange", 55000, 65000, "Petrol", true, "SUV", "DE", "MMI221"),

                new VehicleListing("Volkswagen", "Polo", 2015, "KL7CJLSB8FB030061", "Black", 250000, 8900, "Petrol", true, "Hatchback", "DE", "KTU221"),
                new VehicleListing("Volkswagen", "Polo", 2015, "1J4GW58N11C529249", "Gray", 190000, 12000, "Petrol", true, "Hatchback", "CH", "VUT876"),
                new VehicleListing("Volkswagen", "Polo", 2015, "1FTFX1CV8AFD74163", "White", 400000, 5400, "Gasoline", false, "Hatchback", "RU", "KUT872"),
                new VehicleListing("Volkswagen", "Pantheon", 2020, "4T1BG12K0TU713918", "Gold", 21000, 35000, "Petrol", true, "Saloon", "DE", "PAN000"),

                new VehicleListing("Honda", "S2000", 2005, "1G1JF524027270266", "Red", 290000, 4400, "Gasoline", true, "Convertible", "JP", "S2000"),
                new VehicleListing("Honda", "NSX", 2002, "1HGCP2F34BA129475", "Green", 335000, 3200, "Gasoline", true, "Convertible", "JP", "IIU223"),
                new VehicleListing("Honda", "Jazz", 2017, "1FUPACYB9MH528882", "Yellow", 150000, 5200, "Gasoline", false, "Miniven", "JP", "1azz"),

                new VehicleListing("BMW", "M1", 1979, "3MZBM1L76EM155276", "Black", 180000, 9800, "Petrol", false, "Hatchback", "DE", "M1"),
                new VehicleListing("BMW", "X1", 2014, "1GCHK24U94E204066", "Black", 324500, 8500, "Gasoline", true, "SUV", "DE", "BMWX1"),
                new VehicleListing("BMW", "M2", 2017, "KMHDU46D48U305119", "Gray", 200000, 13500, "Petrol", true, "Saloon", "DE", "BMWPOWER")
            });
        }
    }
}
