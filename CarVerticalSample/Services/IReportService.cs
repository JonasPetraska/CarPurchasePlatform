using CarVerticalSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarVerticalSample.Services
{
    public interface IReportService
    {
        Task<CarHistoryReport> GenerateReportAsync(string VIN);
    }
}
