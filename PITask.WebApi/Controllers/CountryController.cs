using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PITask.Core.Api.DataAndBusiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PITask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public ICountryService CountryService { get; set; }
        public CountryController(ICountryService countryService)
        {
            CountryService = countryService;
            CountryService.GetCountries();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CountryService.GetCountries());
        }
    }
}
