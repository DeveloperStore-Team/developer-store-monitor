namespace SalesEventConsumer.Models
{
    public class SaleItemModel
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
