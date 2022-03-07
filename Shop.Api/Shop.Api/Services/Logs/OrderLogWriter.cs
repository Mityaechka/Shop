using Shop.Api.Data;
using Shop.Api.DTO;
using System;
using System.Threading.Tasks;

namespace Shop.Api.Services.Logs
{
    public class OrderLogWriter : ILogWriter
    {
        private readonly IRepository<OrderLog> _repository;
        private readonly int _orderId;

        public OrderLogWriter(IRepository<OrderLog> repository, int orderId)
        {
            _repository = repository;
            _orderId = orderId;
        }

        public async Task AddLog(LogModel logModel)
        {
            OrderLog orderLog = new OrderLog
            {
                OrderId = _orderId,
                Log = new Log
                {
                    Level = logModel.Level,
                    Message = logModel.Message,
                    Date = DateTime.Now
                }
            };

            _repository.Add(orderLog);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {

        }
    }

}
