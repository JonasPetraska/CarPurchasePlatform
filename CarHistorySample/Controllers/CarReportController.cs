using CarHistorySample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHistorySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReportController : ControllerBase
    {
        private readonly ICarReportService _service;
        public CarReportController(ICarReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string vin)
        {
            var result = await _service.GetCarReportAsync(vin);
            return Ok(result);
        }
    }
}
