using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SalesEventConsumer.Events;

namespace SalesEventConsumer.Hubs
{
    public class SalesHub : Hub
    {
        private readonly ILogger<SalesHub> _logger;

        public SalesHub(ILogger<SalesHub> logger)
        {
            _logger = logger;
        }

        public async Task SendSaleCreated(SaleCreatedEvent sale)
        {
            _logger.LogInformation("Broadcasting SaleCreatedEvent: {@Sale}", sale);
            await Clients.All.SendAsync("ReceiveSaleCreated", sale);
        }

        public async Task SendSaleModified(SaleModifiedEvent sale)
        {
            _logger.LogInformation("Broadcasting SaleModifiedEvent: {@Sale}", sale);
            await Clients.All.SendAsync("ReceiveSaleModified", sale);
        }

        public async Task SendSaleCanceled(SaleCanceledEvent sale)
        {
            _logger.LogInformation("Broadcasting SaleCanceledEvent: {@Sale}", sale);
            await Clients.All.SendAsync("ReceiveSaleCanceled", sale);
        }

        public async Task SendItemCanceled(ItemCanceledEvent item)
        {
            _logger.LogInformation("Broadcasting ItemCanceledEvent: {@Item}", item);
            await Clients.All.SendAsync("ReceiveItemCanceled", item);
        }
    }
}
