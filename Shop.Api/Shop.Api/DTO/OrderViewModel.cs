using Shop.Api.Data;

namespace Shop.Api.DTO
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
    }
}
