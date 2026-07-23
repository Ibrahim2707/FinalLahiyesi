using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.Product
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public bool IsFeatured { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public List<IFormFile> ? OtherImages { get; set; }
    }
}
