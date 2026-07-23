namespace Final.BL.DTOs.Basket
{
    public class BasketGetDTO
    {
        public string BasketKey { get; set; } = string.Empty;
        public IReadOnlyList<BasketItemGetDTO> Items { get; set; } = [];
        public int TotalQuantity => Items.Sum(x => x.Quantity);
        public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    }
}
