using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SalesEventConsumer.Events;
using SalesEventConsumer.Hubs;

namespace SalesEventConsumer.Consumers
{
    public class SaleCreatedConsumer : IConsumer<SaleCreatedEvent>
    {
        private readonly IHubContext<SalesHub> _hubContext;

        public SaleCreatedConsumer(IHubContext<SalesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<SaleCreatedEvent> context)
        {
            var sale = context.Message;
            await _hubContext.Clients.All.SendAsync("ReceiveSaleCreated", sale);
        }
    }
}
