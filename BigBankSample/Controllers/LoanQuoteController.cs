using BigBankSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBankSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanQuoteController : ControllerBase
    {
        private ILoanQuoteService _service;

        public LoanQuoteController(ILoanQuoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Quote(string personalCode, double price, int maxLoanPercentage)
        {
            var quote = await _service.ProduceQuoteAsync(personalCode, price, maxLoanPercentage);
            return Ok(quote);
        }
    }
}
