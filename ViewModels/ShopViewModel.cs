using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp_MvvM.Models;
using WpfApp_MvvM.Services;

namespace WpfApp_MvvM.ViewModels
{
    class ShopViewModel : ViewModelBase
    {
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products { get => products; set => Set(ref products, value); }

        private ObservableCollection<CartItem> cartItems;
        public ObservableCollection<CartItem> CartItems { get => cartItems; set => Set(ref cartItems, value); }

        private CartService cartService = new CartService();

        private decimal total = 0;
        public decimal Total { get => total; set => Set(ref total, value); }

        public ShopViewModel()
        {
            using (var db = new ShopContext())
            {
                Products = new ObservableCollection<Product>(db.Products);
            }
        }

        private RelayCommand<Product> addToCartCommand;
        public RelayCommand<Product> AddToCartCommand
        {
            get => addToCartCommand ?? (addToCartCommand = new RelayCommand<Product>(
              param =>
              {
                  cartService.Add(param);
                  CartItems = new ObservableCollection<CartItem>(cartService.GetItems());
                  Total = CartItems.Sum(x => x.TotalPrice);
              }
              ));
        }

    }
}
