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
    public class ProductController : ControllerBase
    {
        public IProductService ProductService { get; set; }
        public ProductController(IProductService productService)
        {
            ProductService = productService;
            ProductService.GetProducts("Amerika");
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ProductService.GetProducts());
        }
    }
}
