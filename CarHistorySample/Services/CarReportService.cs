using CarHistorySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHistorySample.Services
{
    public class CarReportService : ICarReportService
    {
        public Task<CarReport> GetCarReportAsync(string vin)
        {
            //Generate a psuedo-random report
            var report = new CarReport();
            report.VIN = vin;

            var firstChar = vin[0];
            if (new char[] { '1', '4', '5' }.Contains(firstChar))
                report.Country = "US";
            else if (firstChar == '2')
                report.Country = "CA";
            else if (firstChar == '3')
                report.Country = "MX";
            else if (firstChar == 'J')
                report.Country = "JP";
            else if (firstChar == 'K')
                report.Country = "KR";
            else if (firstChar == 'S')
                report.Country = "UK";
            else if (firstChar == 'W')
                report.Country = "DE";
            else if (firstChar == 'Y')
                report.Country = "SE";

            var random = new Random();
            report.HadWaterDamage = random.Next(0, 100) > 50 ? true : false;
            report.HasBeenConfiscated = random.Next(0, 100) < 50 ? true : false;
            report.HasBeenSoldBefore = random.Next(0, 100) > 50 ? true : false;
            report.LastListingPrice = report.HasBeenSoldBefore ? random.Next(500, 5000) : 0;
            report.IsWanted = random.Next(0, 100) > 50 ? true : false;
            report.OwnersCount = random.Next(1, 10);


            return Task.FromResult(report);
        }
    }
}
