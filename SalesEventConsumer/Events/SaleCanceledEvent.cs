using System;

namespace SalesEventConsumer.Events
{
    public class SaleCanceledEvent
    {
        public string SaleId { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Consumer { get; set; }
        public string Agency { get; set; }
        public bool IsCanceled { get; set; } = true;
    }
}
