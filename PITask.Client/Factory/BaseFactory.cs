using PITask.Core.Api.Entities;
using PITask.Core.Client.Abstract;
using PITask.Core.Client.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Client.Factory
{
    public static class BaseFactory
    {
        public static SearchProduct CreateInstance(Country country)
        {
            switch (country.Name)
            {
                case CountryFactoryTypes.Amerika:
                    return new AmerikaSearchProduct();
                    break;
                case CountryFactoryTypes.Azerbaijan:
                    return new AzerbaijanSearchProduct();
                    break;
                case CountryFactoryTypes.Germany:
                    return new GermanySearchProduct();
                    break;
                case CountryFactoryTypes.China:
                    return new ChinaSearchProduct();
                    break;
                case CountryFactoryTypes.Turkey:
                    return new TurkeySearchProduct();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
