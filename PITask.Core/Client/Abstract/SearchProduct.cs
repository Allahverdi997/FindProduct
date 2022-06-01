using PITask.Core.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Core.Client.Abstract
{
    public abstract class SearchProduct
    {
        public SearchProduct NextChain { get; set; }
        private EventHandler<int> SearchProductForIdHandler;
        public bool InStock { get; set; }
        public Product Product { get; set; }
        protected abstract void search(object sender,int id);
        public SearchProduct()
        {
            SearchProductForIdHandler += search;
        }

        public void SearchProductForId(int id)
        {
            SearchProductForIdHandler(this, id);
        }
    }
}
