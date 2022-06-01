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
    public class CountryManager : ICountryService
    {
        public List<Country> GetCountries()
        {
            return new List<Country>() 
            { 
                new Country() 
                {  
                    Id=1,Name="Amerika",  Distance=200
                },
                new Country()
                {
                    Id=2,Name="Germany", Distance=500
                },
                new Country()
                {
                    Id=3,Name="Turkey", Distance=600
                },
                new Country()
                {
                    Id=4,Name="Azerbaijan",Distance=650
                },
                new Country()
                {
                    Id=5,Name="China", Distance=900
                }
                };
        }
    }
}
