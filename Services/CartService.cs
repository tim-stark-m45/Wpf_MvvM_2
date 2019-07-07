using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_MvvM.Models;

namespace WpfApp_MvvM.Services
{
    class CartService
    {
        private Dictionary<int, CartItem> cartDictionary = new Dictionary<int, CartItem>();

        public void Add(Product product)
        {
            if (cartDictionary.ContainsKey(product.Id))
                cartDictionary[product.Id].Count++;
            else
                cartDictionary[product.Id] = new CartItem { Item = product, Count = 1 };
        }

        public IEnumerable<CartItem> GetItems()
        {
            return cartDictionary.Values;
        }
    }
}
