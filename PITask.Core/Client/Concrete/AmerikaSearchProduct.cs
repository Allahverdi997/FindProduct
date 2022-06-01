using PITask.Core.Api.Entities;
using PITask.Core.Client.Abstract;
using PITask.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Core.Client.Concrete
{
    public class AmerikaSearchProduct:SearchProduct
    {
        protected override void search(object sender, int id)
        {
            var product = CustomHttpClient.GetResponse("Amerika", id).Result;

            if (product.UnitsInStock == 0)
            {
                NextChain?.SearchProductForId(id);
            }
            else
            {
                InStock = true;
                Product = product;
            }
        }

        public Product GetProduct(int id)
        {
            return CustomHttpClient.GetResponse("Amerika", id).Result;
        }
    }
}
