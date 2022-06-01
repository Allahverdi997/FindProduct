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
    public class ForGermanyController : ControllerBase
    {
        public IProductService ProductService { get; set; }
        public ForGermanyController(IProductService productService)
        {
            ProductService = productService;

            ProductService.GetProducts("Germany");
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ProductService.GetProduct(id));
        }
    }
}
