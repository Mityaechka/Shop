using Microsoft.EntityFrameworkCore;
using Shop.Api.Data;
using Shop.Api.DTO;
using Shop.Api.Services.Logs;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Services
{
    public interface IOrdersService
    {
        Task<int?> AddOrder();
        Task<bool> HasAnyFormOrder();
        Task<Order> GetFormOrder();
        Task<bool> SetOrderStateConfirm(int orderId);
        Task<bool> SetOrderStatePay(int orderId, OrderInformationCreateViewModel orderInformationModel);
        Task<bool> TryAddProduct(int orderId, int productId);
        Task<bool> TryAddProductToFormOrder(int productId);
        Task<bool> SetFormOrderStatePay(OrderInformationCreateViewModel orderInformationModel);
    }

    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly ILogWriterFactory _logWriterFactory;

        public OrdersService(IRepository<Order> orderRepository, IRepository<Product> productRepository, ILogWriterFactory logWriterFactory)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logWriterFactory = logWriterFactory;
        }

        public async Task<bool> HasAnyFormOrder()
        {
            return await _orderRepository.All.AnyAsync(x => x.State == OrderState.Form);
        }

        public async Task<Order> GetFormOrder()
        {
            return await _orderRepository.All.FirstOrDefaultAsync(x => x.State == OrderState.Form);
        }

        public async Task<int?> AddOrder()
        {
            if (await HasAnyFormOrder())
                return null;

            var order = new Order
            {
                State = OrderState.Form
            };

            _orderRepository.Add(order);
            await _orderRepository.SaveAsync();

            return order.Id;
        }

        public async Task<bool> TryAddProductToFormOrder( int productId)
        {
            var order = await GetFormOrder();

            if(order == null)
            {
                return false;
            }

            return await TryAddProduct(order.Id, productId);
        }

        public async Task<bool> TryAddProduct(int orderId, int productId)
        {
            var order = await _orderRepository.All.FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return false;
            }

            using (ILogWriter orderLogWriter = _logWriterFactory.getOrderLogWriter(orderId))
            {
                var isProductExist = await _productRepository.All.AnyAsync(x => x.Id == productId);

                if (!isProductExist)
                {
                    return false;
                }

                if (order.Products.Any(x => x.ProductId == productId))
                {
                    var orderProduct = order.Products.FirstOrDefault(x => x.ProductId == productId);

                    orderProduct.Count++;
                }
                else
                {
                    var orderProduct = new OrderProduct
                    {
                        ProductId = productId,
                        OrderId = orderId,
                        Count = 1
                    };

                    order.Products.Add(orderProduct);
                }

                await _orderRepository.SaveAsync();

                await orderLogWriter.AddLog(new LogModel
                {
                    Level = LogLevel.Info,
                    Message = $"Продукт {productId} успешно добавен в заказ"
                });

                return true;

            }
        }

        public async Task<bool> SetFormOrderStatePay( OrderInformationCreateViewModel orderInformationModel)
        {
            var order = await GetFormOrder();

            if (order == null)
            {
                return false;
            }

            return await SetOrderStatePay(order.Id, orderInformationModel);

        }
            public async Task<bool> SetOrderStatePay(int orderId, OrderInformationCreateViewModel orderInformationModel)
        {
            var order = await _orderRepository.All.FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return false;
            }

            using (ILogWriter orderLogWriter = _logWriterFactory.getOrderLogWriter(orderId))
            {
                if (order.State != OrderState.Form)
                {
                    await orderLogWriter.AddLog(new LogModel
                    {
                        Level = LogLevel.Error,
                        Message = "Заказ находится не в состяние Формируется"
                    });

                    return false;
                }

                if (orderInformationModel == null || !orderInformationModel.IsValid)
                {
                    await orderLogWriter.AddLog(new LogModel
                    {
                        Level = LogLevel.Error,
                        Message = "Отсуствует инфомация о заказе"
                    });

                    return false;
                }

                var orderInformation = new OrderInformation
                {
                    CardNumber = orderInformationModel.CardNumber,
                    Address = orderInformationModel.Address
                };

                order.State = OrderState.Paied;
                order.Information = orderInformation;

                await _orderRepository.SaveAsync();

                await orderLogWriter.AddLog(new LogModel
                {
                    Level = LogLevel.Info,
                    Message = "Заказ успешно оплачен"
                });

                return true;
            }
        }

        public async Task<bool> SetOrderStateConfirm(int orderId)
        {
            var order = await _orderRepository.All.FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return false;
            }

            using (ILogWriter orderLogWriter = _logWriterFactory.getOrderLogWriter(orderId))
            {
                if (order.State != OrderState.Paied)
                {
                    await orderLogWriter.AddLog(new LogModel
                    {
                        Level = LogLevel.Error,
                        Message = "Заказ находится не в состяние Оплачен"
                    });

                    return false;
                }


                order.State = OrderState.Confirmed;

                await _orderRepository.SaveAsync();

                await orderLogWriter.AddLog(new LogModel
                {
                    Level = LogLevel.Info,
                    Message = "Заказ успешно подтвержден"
                });

                return true;
            }
        }
    }
}
