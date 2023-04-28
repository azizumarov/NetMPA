using MassTransit;
using NetMPA.Carting.Api.Messages;
using NetMPA.Carting.Bll.Interfaces;

namespace NetMPA.Carting.Api.Consumers
{
    public class DeleteProductMessageConsumer : IConsumer<DeleteProductMessage>
    {
        private readonly ILogger<DeleteProductMessageConsumer> logger;
        private readonly ICartingService cartingService;

        public DeleteProductMessageConsumer(ILogger<DeleteProductMessageConsumer> logger, ICartingService cartingService)
        {
            this.logger = logger;
            this.cartingService = cartingService;
        }

        public async Task Consume(ConsumeContext<DeleteProductMessage> context)
        {
            // to do perform some removing
            //await this.cartingService;

        }
    }
}
