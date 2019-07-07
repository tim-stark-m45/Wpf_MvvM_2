using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_MvvM.Models
{
    class CartItem
    {
        public Product Item { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get => Item.Price * Count; }
    }
}
