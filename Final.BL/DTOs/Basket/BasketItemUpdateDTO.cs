using System.ComponentModel.DataAnnotations;

namespace Final.BL.DTOs.Basket
{
    public class BasketItemUpdateDTO
    {
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
