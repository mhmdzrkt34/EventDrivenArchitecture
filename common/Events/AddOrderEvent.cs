using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Events
{
    public class AddOrderEvent
    {

        public string id {  get; set; }

        public double totalPrice { get; set; }
    }
}
