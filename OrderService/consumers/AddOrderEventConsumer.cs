using common.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.consumers
{
    public class AddOrderEventConsumer : IConsumer<AddOrderEvent>
    {
        public async Task Consume(ConsumeContext<AddOrderEvent> context)
        {


            Console.WriteLine($"total price:{context.Message.totalPrice}");


             await Task.CompletedTask;
        }
    }
}
