
using ApiService.models;
using common.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly ISendEndpointProvider _sendEndpointProvider;

        private readonly IBus _bus;


        public AdminController(ISendEndpointProvider sendEndpointProvider,IBus bus)
        {


            _sendEndpointProvider = sendEndpointProvider;

            _bus= bus;
        }


        [HttpPost]

        public async Task<IActionResult> addProduct()
        {


            try
            {

                Product product = new Product()
                {

                    name = "rtx 3070"

                };

                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:add-product-event-queue"));

                await sendEndpoint.Send(new AddProductEvent()
                {


                    id = product.id,
                    name = product.name,
                });




                return StatusCode(201, new
                {


                    status = 201,


                    body = new
                    {


                        message = "event sended with the product"
                    },

                    type = "event sended"
                });




            }catch(Exception ex) {



                return StatusCode(500, new
                {


                    status = 500,

                    body = new
                    {

                        message = "internal server error"
                    },

                    type = "server error"

                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder()
        {

            try
            {


                Order order = new Order()
                {

                    totalPrice = 5678.76
                };


                await _bus.Publish(new AddOrderEvent()
                {

                    id = order.id,
                    totalPrice = order.totalPrice,
                });

                return StatusCode(201, new
                {


                    status = 201,


                    body = new
                    {


                        message = "event sended with the order"
                    },

                    type = "add order event sended"
                });




            }
            catch (Exception ex)
            {


                return StatusCode(500, new
                {


                    status = 500,
                    body = new
                    {

                        message = "internal server error"
                    },
                    type = "server error"
                });
            }



        }
    }
}
