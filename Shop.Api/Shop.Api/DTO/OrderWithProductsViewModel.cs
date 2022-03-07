using Shop.Api.Data;
using System.Collections.Generic;

namespace Shop.Api.DTO
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
    }

    public class OrderWithProductsViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
    }

    public class OrderWithProductsAndLogsViewModel
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
        public List<LogViewModel> Logs { get; set; }
    }

    public class LogViewModel
    {
        public int Id { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
    }

    public class OrderProductViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
