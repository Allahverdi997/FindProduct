using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PITask.Core.Api.DataAndBusiness.Abstract;
using PITask.Core.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PITask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForAmerikaController : ControllerBase
    {
        public IProductService ProductService { get; set; }
        public ForAmerikaController(IProductService productService)
        {
            ProductService = productService;
            ProductService.GetProducts("Amerika");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ProductService.GetProduct(id));
        }
    }
}
