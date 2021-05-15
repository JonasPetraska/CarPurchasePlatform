using LietuvosDraudimasSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LietuvosDraudimasSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;
        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuote(string personalCode, string licensePlate)
        {
            var result = await _service.GetQuoteAsync(personalCode, licensePlate);
            return Ok(result);
        }
    }
}
