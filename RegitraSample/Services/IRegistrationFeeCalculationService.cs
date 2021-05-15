using RegitraSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegitraSample.Services
{
    public interface IRegistrationFeeCalculationService
    {
        Task<RegistrationFeeEstimate> CalculateAsync(string vin);
    }
}
