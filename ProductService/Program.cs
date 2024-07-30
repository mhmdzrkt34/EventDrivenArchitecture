using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Consumers;

namespace ProductService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<AddProductEventConsumer>();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });

                            cfg.ReceiveEndpoint("add-product-event-queue", e =>
                            {
                                e.ConfigureConsumer<AddProductEventConsumer>(context);
                            });
                        });
                    });

                    services.AddMassTransitHostedService(true);
                })
                .Build();

            await host.RunAsync();
        }
    }
}
