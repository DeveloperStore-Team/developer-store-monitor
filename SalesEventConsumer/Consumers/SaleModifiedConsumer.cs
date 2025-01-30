using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SalesEventConsumer.Events;
using SalesEventConsumer.Hubs;

namespace SalesEventConsumer.Consumers
{
    public class SaleModifiedConsumer : IConsumer<SaleModifiedEvent>
    {
        private readonly IHubContext<SalesHub> _hubContext;

        public SaleModifiedConsumer(IHubContext<SalesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<SaleModifiedEvent> context)
        {
            var sale = context.Message;
            await _hubContext.Clients.All.SendAsync("ReceiveSaleModified", sale);
        }
    }
}
