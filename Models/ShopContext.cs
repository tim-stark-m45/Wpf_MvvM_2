using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_MvvM.Models
{
    class ShopContext : DbContext
    {
        static ShopContext()
        {
            Database.SetInitializer(new ShopContextInitializer());
        }
        public ShopContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
