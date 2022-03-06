using System.Collections.Generic;

namespace Shop.Api.Data
{
    public class Order
    {
        public int Id { get; set; }
        public virtual List<OrderProduct> Products { get; set; }
        public OrderState State { get; set; }

        public int? InformationId { get; set; }
        public virtual OrderInformation Information { get; set; }

        public virtual List<OrderLog> Logs { get; set; }
    }
}
