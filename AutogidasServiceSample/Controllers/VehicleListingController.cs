using AutogidasServiceSample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutogidasServiceSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleListingController : Controller
    {
        private IVehicleListingService _service;
        public VehicleListingController(IVehicleListingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string manufacturer, string model, int year)
        {
            var listing = await _service.GetAsync(manufacturer, model, year);
            return Ok(listing);
        }
    }
}
