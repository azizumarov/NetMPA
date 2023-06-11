using MassTransit;
using NetMPA.Messages.Dto;
using NetMPA.Carting.Bll.Interfaces;

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
