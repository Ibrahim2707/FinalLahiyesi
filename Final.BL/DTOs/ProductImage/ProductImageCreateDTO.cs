using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Final.BL.DTOs.ProductImage
{
    public class ProductImageCreateDTO
    {
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}