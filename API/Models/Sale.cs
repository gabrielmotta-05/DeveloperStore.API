namespace DeveloperStore.API.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public decimal TotalValue { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; }
    }
}
