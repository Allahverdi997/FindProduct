using Newtonsoft.Json;
using PITask.Core.Api.Entities;
using PITask.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Core.Core
{
    public static class CustomHttpClient
    {
        public static async Task<Product> GetResponse(string country,int id)
        {
            HttpClient httpClient = new HttpClient();
            string baseUrl= "https://localhost:44331/api/For" + country + "/" + id.ToString();
            var response=await httpClient.GetAsync(baseUrl);
            if(!response.IsSuccessStatusCode)
                return null;

            var model = await response.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<Product>(model);
            return convert;
        }

        public static async Task<List<ProductViewModel>> GetProducts()
        {
            HttpClient httpClient = new HttpClient();
            string baseUrl = "https://localhost:44331/api/Product";
            var response = await httpClient.GetAsync(baseUrl);
            if (!response.IsSuccessStatusCode)
                return null;

            var model = await response.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<List<ProductViewModel>>(model);
            return convert;
        }

        public static async Task<List<Country>> GetCountries()
        {
            HttpClient httpClient = new HttpClient();
            string baseUrl = "https://localhost:44331/api/Country";
            var response = await httpClient.GetAsync(baseUrl);
            if (!response.IsSuccessStatusCode)
                return null;

            var model = await response.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<List<Country>>(model);
            return convert;
        }
    }
}
