using PITask.Core.Client.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Client.Chains
{
    public static class ChainClass
    {
        public static List<SearchProduct> Chains { get; set; }
        public static void SetChain(SearchProduct _old, SearchProduct _next)
        {
            _old.NextChain = _next;
        }

        public static bool SetChain(SearchProduct entity, List<SearchProduct> searchProducts)
        {
            foreach (var item in searchProducts)
            {
                if (item.GetType() == entity.GetType())
                {
                    entity.NextChain = item.NextChain;
                    entity = entity.NextChain;
                    var a = SetChain(entity, searchProducts);
                    if (!a)
                        return false;
                }
            }
            return false;
        }

        public static List<SearchProduct> GetChainName(SearchProduct chain, List<SearchProduct> chains)
        {
            if (chain == null)
                return null;

            chains.Add(chain);
            Chains = chains;
            chain = chain.NextChain;
            var result = GetChainName(chain, chains);
            if (result == null)
                return null;

            return chains;
        }
    }
}
