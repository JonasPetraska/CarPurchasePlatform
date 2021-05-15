using BTASample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTASample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceQuoteController : ControllerBase
    {
        private readonly IInsuranceQuoteService _insuranceQuoteService;
        public InsuranceQuoteController(IInsuranceQuoteService insuranceQuoteService)
        {
            _insuranceQuoteService = insuranceQuoteService;
        }

        [HttpGet]
        public async Task<IActionResult> Quote(string personalCode, string licensePlate)
        {
            var quote = await _insuranceQuoteService.Quote(personalCode, licensePlate);
            return Ok(quote);
        }
    }
}
