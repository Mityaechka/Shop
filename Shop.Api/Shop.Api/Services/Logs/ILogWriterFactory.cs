namespace Shop.Api.Services.Logs
{
    public interface ILogWriterFactory
    {
        ILogWriter getOrderLogWriter(int orderId);
    }
}