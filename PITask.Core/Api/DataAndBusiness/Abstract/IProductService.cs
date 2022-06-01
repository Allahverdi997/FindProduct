using PITask.Core.Api.Entities;
using PITask.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Core.Api.DataAndBusiness.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts(string country);
        public List<ProductViewModel> GetProducts();
        Product GetProduct(int id);
    }
}
