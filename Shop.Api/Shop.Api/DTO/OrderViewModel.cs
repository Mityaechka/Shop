using Shop.Api.Data;
using System.Collections.Generic;

namespace Shop.Api.DTO
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
    }

    public class OrderProductViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
