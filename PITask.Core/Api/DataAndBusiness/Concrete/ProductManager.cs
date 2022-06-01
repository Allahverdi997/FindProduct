using AutoMapper;
using PITask.Core.Api.DataAndBusiness.Abstract;
using PITask.Core.Api.Entities;
using PITask.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Core.Api.DataAndBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        public List<Product> Products { get; set; }
        public IMapper Mapper { get; set; }
        public ProductManager(IMapper mapper)
        {
            Mapper = mapper;
        }
        public List<Product> GetProducts(string controller)
        {

            switch (controller)
            {
                case "Amerika":
                    Products = new List<Product>()
                    {
                        new Product() { Id=1, Name="TV",Size=200, Price=800, UnitsInStock=5},
                        new Product() { Id=2, Name="Mouse",Size=0.3, Price=5, UnitsInStock=0},
                        new Product() { Id=3, Name="Mobil Phone",Size=1.2, Price=600, UnitsInStock=15},
                        new Product() { Id=4, Name="Adapter", Price=6, UnitsInStock=0},
                        new Product() { Id=4, Name="Processor", Price=15, UnitsInStock=3},
                        new Product() { Id=4, Name="Masa", Price=30, UnitsInStock=3},
                        new Product() { Id=1, Name="Soyuducu",Size=400, Price=800, UnitsInStock=5}
                    };
                    return Products;
                case "Azerbaijan":
                    Products = new List<Product>()
                    {
                        new Product() { Id=1, Name="TV",Size=200, Price=800, UnitsInStock=5},
                        new Product() { Id=2, Name="Mouse",Size=0.3, Price=5, UnitsInStock=7},
                        new Product() { Id=3, Name="Mobil Phone",Size=1.2, Price=600, UnitsInStock=0},
                        new Product() { Id=4, Name="Adapter", Price=6, UnitsInStock=0},
                        new Product() { Id=4, Name="Processor", Price=15, UnitsInStock=3},
                        new Product() { Id=4, Name="Masa", Price=30, UnitsInStock=3},
                        new Product() { Id=1, Name="Soyuducu",Size=400, Price=800, UnitsInStock=5}
                    };
                    return Products;
                case "China":
                    Products = new List<Product>()
                    {
                        new Product() { Id=1, Name="TV",Size=200, Price=800, UnitsInStock=5},
                        new Product() { Id=2, Name="Mouse",Size=0.3, Price=5, UnitsInStock=8},
                        new Product() { Id=3, Name="Mobil Phone",Size=1.2, Price=600, UnitsInStock=10},
                        new Product() { Id=4, Name="Adapter", Price=6, UnitsInStock=0},
                        new Product() { Id=4, Name="Processor", Price=15, UnitsInStock=0},
                        new Product() { Id=4, Name="Masa", Price=30, UnitsInStock=3},
                        new Product() { Id=1, Name="Soyuducu",Size=400, Price=800, UnitsInStock=5}
                    };
                    return Products;
                case "Germany":
                    Products = new List<Product>()
                    {
                        new Product() { Id=1, Name="TV",Size=200, Price=800, UnitsInStock=5},
                        new Product() { Id=2, Name="Mouse",Size=0.3, Price=5, UnitsInStock=12},
                        new Product() { Id=3, Name="Mobil Phone",Size=1.2, Price=600, UnitsInStock=15},
                        new Product() { Id=4, Name="Adapter", Price=6, UnitsInStock=0},
                        new Product() { Id=4, Name="Processor", Price=15, UnitsInStock=11},
                        new Product() { Id=4, Name="Masa", Price=30, UnitsInStock=0},
                        new Product() { Id=1, Name="Soyuducu",Size=400, Price=800, UnitsInStock=5}
                    };
                    return Products;
                case "Turkey":
                    Products = new List<Product>()
                    {
                        new Product() { Id=1, Name="TV",Size=200, Price=800, UnitsInStock=5},
                        new Product() { Id=2, Name="Mouse",Size=0.3, Price=5, UnitsInStock=20},
                        new Product() { Id=3, Name="Mobil Phone",Size=1.2, Price=600, UnitsInStock=15},
                        new Product() { Id=4, Name="Adapter", Price=6, UnitsInStock=0},
                        new Product() { Id=4, Name="Processor", Price=15, UnitsInStock=3},
                        new Product() { Id=4, Name="Masa", Price=30, UnitsInStock=3},
                        new Product() { Id=1, Name="Soyuducu",Size=400, Price=800, UnitsInStock=0}
                    };
                    return Products;
                default:
                    break;
            }

            return Products;
        }

        public List<ProductViewModel> GetProducts()
        {
            Products = new List<Product>()
                    {
                        new Product() { Id=1, Name="TV",Size=200, Price=800, UnitsInStock=5},
                        new Product() { Id=2, Name="Mouse",Size=0.3, Price=5, UnitsInStock=0},
                        new Product() { Id=3, Name="Mobil Phone",Size=1.2, Price=600, UnitsInStock=15},
                        new Product() { Id=4, Name="Adapter", Price=6, UnitsInStock=3},
                        new Product() { Id=4, Name="Processor", Price=15, UnitsInStock=3},
                        new Product() { Id=4, Name="Masa", Price=30, UnitsInStock=3},
                        new Product() { Id=1, Name="Soyuducu",Size=400, Price=800, UnitsInStock=5}
                    };

            var model = Mapper.Map <List<ProductViewModel>>(Products);

            return model;
        }

        public Product GetProduct(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);
            if (product.UnitsInStock == 0)
                return new Product();

            return product;
        }


    }
}
