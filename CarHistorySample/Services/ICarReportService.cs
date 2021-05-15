using CarHistorySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHistorySample.Services
{
    public interface ICarReportService
    {
        Task<CarReport> GetCarReportAsync(string vin);
    }
}
