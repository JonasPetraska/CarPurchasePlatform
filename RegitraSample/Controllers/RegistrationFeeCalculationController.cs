using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegitraSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegitraSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationFeeCalculationController : ControllerBase
    {
        private readonly IRegistrationFeeCalculationService _service;
        public RegistrationFeeCalculationController(IRegistrationFeeCalculationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Calculate(string vin)
        {
            var fee = await _service.CalculateAsync(vin);
            return Ok(fee);
        }
    }
}
