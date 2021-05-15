using CarVerticalSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarVerticalSample.Services
{
    public class DefaultReportService : IReportService
    {
        public Task<CarHistoryReport> GenerateReportAsync(string VIN)
        {
            //Generate a psuedo-random report
            var report = new CarHistoryReport();
            report.VIN = VIN;

            var firstChar = VIN[0];
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
            report.IsStolen = random.Next(0, 100) > 50 ? true : false;
            report.HadAccidents = random.Next(0, 100) < 50 ? true : false;
            report.WasTaxi = random.Next(0, 100) > 50 ? true : false;
            report.AccidentsCount = report.HadAccidents ? random.Next(1, 10) : 0;
            report.OwnersCount = random.Next(1, 6);

            return Task.FromResult(report);
        }
    }
}
