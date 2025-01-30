using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SalesEventConsumer.Events;
using SalesEventConsumer.Hubs;

namespace SalesEventConsumer.Consumers
{
    public class SaleCanceledConsumer : IConsumer<SaleCanceledEvent>
    {
        private readonly IHubContext<SalesHub> _hubContext;

        public SaleCanceledConsumer(IHubContext<SalesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<SaleCanceledEvent> context)
        {
            var sale = context.Message;
            await _hubContext.Clients.All.SendAsync("ReceiveSaleCanceled", sale);
        }
    }
}
