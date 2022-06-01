using PITask.Client.Chains;
using PITask.Client.Delivery;
using PITask.Client.Factory;
using PITask.Core.Api.Entities;
using PITask.Core.Client.Abstract;
using PITask.Core.Client.Concrete;
using PITask.Core.Core;
using PITask.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PITask.Client
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(ClientMessages.LoginMessage);
            Console.WriteLine(ClientMessages.ProductMessage);
            Console.WriteLine(ClientMessages.Space);
            Console.WriteLine(ClientMessages.Products);
            var products = CustomHttpClient.GetProducts().Result;

            foreach (var item in products)
            {
                Console.WriteLine($"Name:{item.Name}, Hidden-Id:{item.Id}");
            }
            Console.WriteLine(ClientMessages.Space);
            Console.WriteLine(ClientMessages.CountrMessage);
            var countries = CustomHttpClient.GetCountries().Result;

            foreach (var item in countries)
            {
                Console.WriteLine($"Name:{item.Name}, Hidden-Id:{item.Id}");
            }
            Console.WriteLine(ClientMessages.Space);
            Console.WriteLine(ClientMessages.CountryWithId);
            var countryId = Convert.ToInt32(Console.ReadLine());
            var country = countries.FirstOrDefault(x => x.Id == countryId);
            Console.WriteLine($"{country.Name} The country has a very beautiful nature");
            Console.WriteLine(ClientMessages.Space);

            Dictionary<int,Country> keyValues = new Dictionary<int, Country>();

            for (int i = 0; i < countries.Count; i++)
            {
               keyValues.Add(Math.Abs(countries[i].Distance - country.Distance),countries[i]);
            }

            var orderedCountries=keyValues.OrderBy(x => x.Key).ToList();

            Dictionary<SearchProduct, SearchProduct> corValues = new Dictionary<SearchProduct, SearchProduct>();

            List<SearchProduct> searchProducts = new List<SearchProduct>();
            for (int i = 0; i < orderedCountries.Count-1; i++)
            {
                corValues.Add(BaseFactory.CreateInstance(orderedCountries[i].Value), BaseFactory.CreateInstance(orderedCountries[i + 1].Value));
                var old = BaseFactory.CreateInstance(orderedCountries[i].Value);
                var next = BaseFactory.CreateInstance(orderedCountries[i + 1].Value);
                ChainClass.SetChain(old, next);
                searchProducts.Add(old);
            }

            Console.WriteLine(ClientMessages.ProductWithId);

            int id = Convert.ToInt32(Console.ReadLine());

            if(searchProducts[0].NextChain!=null)
            {
                ChainClass.SetChain(searchProducts[0].NextChain, searchProducts);
            }

            string _country = "";
            searchProducts[0].SearchProductForId(id);
            List<SearchProduct> chains = new List<SearchProduct>();
            ChainClass.GetChainName(searchProducts[0], chains);

            var p = new Product();
            bool inStock = false;

            foreach (var item in ChainClass.Chains)
            {
                if (item.InStock == true)
                {
                    _country = item.GetType().Name.Remove(item.GetType().Name.IndexOf('S'), (item.GetType().Name.Length) - item.GetType().Name.IndexOf('S'));
                    p = item.Product;
                    inStock = true;
                    break;
                }
                    
            }
            if(inStock)
            {
                Console.WriteLine($"{p.Name} isimli mehsul {_country} olkesinde {p.UnitsInStock} eded tapildi. \nSifaris vermek isterdinizmi?");
                Console.WriteLine(ClientMessages.OrderMessage);
                var e = Console.ReadKey();
                int distance = 0;
                if (e.Key == ConsoleKey.Y)
                {
                    foreach (var item in orderedCountries)
                    {
                        if (item.Value.Name == _country)
                        {
                            distance = item.Key;
                            break;
                        }
                    }
                }

                var delivery = DeliveryClass.SetDelivery(distance, p.Size);
                Console.WriteLine($"Catdirilma Vasitesi:{delivery} ile {p.Name} mehsulu gonderildi.");
            }
            else
            {
                Console.WriteLine(ClientMessages.NoProduct);
            }
        }
    }
}
