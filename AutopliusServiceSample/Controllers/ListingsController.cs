using AutopliusServiceSample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutopliusServiceSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private IListingService _service;
        public ListingsController(IListingService service)
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
