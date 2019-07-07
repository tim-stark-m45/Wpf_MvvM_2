using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp_MvvM.Models
{
    class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Image { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        [Range(0,1000)]
        public int Count { get; set; }
    }
}
