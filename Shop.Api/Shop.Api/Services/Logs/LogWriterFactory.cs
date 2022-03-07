using Shop.Api.Data;

namespace Shop.Api.Services.Logs
{
    public class LogWriterFactory : ILogWriterFactory
    {
        private readonly IRepository<OrderLog> _orderLogRepository;

        public LogWriterFactory(IRepository<OrderLog> orderLogRepository)
        {
            _orderLogRepository = orderLogRepository;
        }

        public ILogWriter getOrderLogWriter(int orderId)
        {
            return new OrderLogWriter(_orderLogRepository, orderId);
        }
    }

}
