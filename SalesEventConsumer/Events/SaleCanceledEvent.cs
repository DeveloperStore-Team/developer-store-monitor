using System;

namespace SalesEventConsumer.Events
{
    public class SaleCanceledEvent
    {
        public Guid SaleId { get; set; }
        public DateTime CanceledAt { get; set; }
    }
}
