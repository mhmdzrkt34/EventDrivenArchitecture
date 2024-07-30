using common.Events;
using MassTransit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Consumers
{
    public class AddProductEventConsumer : IConsumer<AddProductEvent>
    {
        public async Task Consume(ConsumeContext<AddProductEvent> context)
        {

            Console.WriteLine($"event recieved:name:{context.Message.name}");



            await Task.CompletedTask;
        }
    }
}
