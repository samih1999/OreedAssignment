using System.Collections.Generic;

namespace personalsami.Entity
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
