using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_MvvM.Models
{
    class ShopContextInitializer : CreateDatabaseIfNotExists<ShopContext>
    {
        string api = @"https://api.mockaroo.com/api/generate.json?key=01a2dc90&schema=Product&count=10";
        protected override void Seed(ShopContext context)
        {
            WebClient webClient = new WebClient();
            var data = webClient.DownloadString(api);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(data);
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
