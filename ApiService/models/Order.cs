namespace ApiService.models
{
    public class Order
    {

        public string id { get; set; }

        public double totalPrice { get; set; }


        public DateTime time { get; set; }


        public Order()
        {


            id=Guid.NewGuid().ToString();


            time = DateTime.UtcNow;
        }
    }
}
