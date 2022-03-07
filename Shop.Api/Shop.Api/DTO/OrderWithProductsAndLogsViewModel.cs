using Shop.Api.Data;
using System.Collections.Generic;

namespace Shop.Api.DTO
{
    public class OrderWithProductsAndLogsViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
        public List<LogViewModel> Logs { get; set; }

        public OrderInformationViewModel Information { get; set; }
    }
}
