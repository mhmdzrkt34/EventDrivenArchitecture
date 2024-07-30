using MassTransit;
using Microsoft.Extensions.Hosting;
using OrderService.consumers;

namespace OrderService
{
    public class Program
    {
        public  static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddMassTransit(x =>
                  {
                      x.AddConsumer<AddOrderEventConsumer>();

                      x.UsingRabbitMq((context, cfg) =>
                      {
                          cfg.Host("localhost", "/", h =>
                          {
                              h.Username("guest");
                              h.Password("guest");
                          });

                          cfg.ReceiveEndpoint("add-order-event-queue", e =>
                          {
                              e.ConfigureConsumer<AddOrderEventConsumer>(context);
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
