using System;

namespace SalesEventConsumer.Events
{
    public class ItemCanceledEvent
    {
        public string SaleId { get; set; }
        public string SaleNumber { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
