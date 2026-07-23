using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Entities
{
    public class Product:BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public bool IsFeatured { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductParameter> ProductParameters { get; set; }
        public ICollection<ProductImage> Images { get; set; } 
        public ICollection<BasketItem> BasketItems { get; set; } = [];
    }
}
