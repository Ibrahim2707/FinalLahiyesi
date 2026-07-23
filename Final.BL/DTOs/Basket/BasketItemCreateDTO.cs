using System.ComponentModel.DataAnnotations;

namespace Final.BL.DTOs.Basket
{
    public class BasketItemCreateDTO
    {
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;
    }
}
