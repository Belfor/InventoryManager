using Invenotry.Infrastructure.Events.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Invenotry.Infrastructure.Consumers
{
    public class DeleteItemConsumer : IConsumer<DeleteItem>
    {
        private readonly ILogger<DeleteItemConsumer> _logger;
        public DeleteItemConsumer(ILogger<DeleteItemConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<DeleteItem> context)
        {
            _logger.LogInformation($"El item con id {context.Message.Guid} ha sido eliminado");
            return Task.CompletedTask;
        }
    }
}
