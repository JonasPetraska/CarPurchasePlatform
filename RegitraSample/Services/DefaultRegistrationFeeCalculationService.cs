using RegitraSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegitraSample.Services
{
    public class DefaultRegistrationFeeCalculationService : IRegistrationFeeCalculationService
    {
        public Task<RegistrationFeeEstimate> CalculateAsync(string vin)
        {
            var fee = new RegistrationFeeEstimate();
            fee.VIN = vin;

            var random = new Random();
            var co2 = random.Next(0, 300);

            fee.RegistrationFee = Math.Round(co2 * 1.2, 2);
            fee.AllowedToRegister = co2 > 250 ? false : true;

            return Task.FromResult(fee);
        }
    }
}
