using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwedbankSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedbankSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaseQuoteController : ControllerBase
    {
        private readonly ILeaseQuoteService _service;
        public LeaseQuoteController(ILeaseQuoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Quote(string personalCode, double price, int period, int initialDepositPercentage, int leftOverPercentage)
        {
            var result = await _service.CalculateQuote(personalCode, price, period, initialDepositPercentage, leftOverPercentage);
            return Ok(result);
        }
    }
}
