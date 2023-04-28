using MassTransit;
using NetMPA.Carting.Api.Messages;
using NetMPA.Carting.Bll.Interfaces;
using NetMPA.Carting.Bll.Services;

namespace NetMPA.Carting.Api.Consumers
{
    public class DeleteCategoryMessageConsumer : IConsumer<DeleteCategoryMessage>
    {
        private readonly ILogger<DeleteCategoryMessageConsumer> logger;
        private readonly ICartingService cartingService;

        public DeleteCategoryMessageConsumer(ILogger<DeleteCategoryMessageConsumer> logger, ICartingService cartingService)
        {
            this.logger = logger;
            this.cartingService = cartingService;
        }

        public async Task Consume(ConsumeContext<DeleteCategoryMessage> context)
        {
            // to do perform some removing
            //await this.cartingService;
            
        }
    }
}
