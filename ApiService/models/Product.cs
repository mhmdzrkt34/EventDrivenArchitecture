using System.Reflection.Metadata;

namespace ApiService.models
{
    public class Product
    {

        public string id { get; set; }


        public string name { get; set; }


        public DateTime time { get; set; }



        public Product()
        {


            id = Guid.NewGuid().ToString();

                time = DateTime.Now;
        }
    }
}
