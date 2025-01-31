using System;
using System.Collections.Generic;
using SalesEventConsumer.Models;

namespace SalesEventConsumer.Events
{
    public class SaleModifiedEvent
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public List<SaleItemEvent> Items { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discounts { get; set; }
    }
}
