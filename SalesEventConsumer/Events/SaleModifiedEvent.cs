using System;
using System.Collections.Generic;
using SalesEventConsumer.Models;

namespace SalesEventConsumer.Events
{
    public class SaleModifiedEvent
    {
        public string SaleId { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Consumer { get; set; }
        public string Agency { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discounts { get; set; }
        public List<SaleItemModel> Items { get; set; }
    }
}
