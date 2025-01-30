using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SalesEventConsumer.Events;
using SalesEventConsumer.Hubs;

namespace SalesEventConsumer.Consumers
{
    public class ItemCanceledConsumer : IConsumer<ItemCanceledEvent>
    {
        private readonly IHubContext<SalesHub> _hubContext;

        public ItemCanceledConsumer(IHubContext<SalesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<ItemCanceledEvent> context)
        {
            var item = context.Message;
            await _hubContext.Clients.All.SendAsync("ReceiveItemCanceled", item);
        }
    }
}
