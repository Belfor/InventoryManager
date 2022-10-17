using Invenotry.Infrastructure.Events.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Invenotry.Infrastructure.Consumers
{
    public class ExpirationDateConsumer : IConsumer<ExpirationDateItem>
    {
        private readonly ILogger<ExpirationDateConsumer> _logger;
        public ExpirationDateConsumer(ILogger<ExpirationDateConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<ExpirationDateItem> context)
        {
            _logger.LogInformation($"El item con id {context.Message.Guid} ha alcanzando su tiempo de expiración {context.Message.ExpirationDate}");
            return Task.CompletedTask;
        }
    }
}
