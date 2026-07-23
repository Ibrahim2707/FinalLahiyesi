namespace Final.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string BasketKey { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; } = null!;
    }
}
