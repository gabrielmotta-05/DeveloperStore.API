namespace DeveloperStore.API.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
