using Shop.Api.Data;
using System.Collections.Generic;

namespace Shop.Api.DTO
{
    public class OrderWithProductsViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
    }
}
