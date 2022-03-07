using Shop.Api.DTO;
using System;
using System.Threading.Tasks;

namespace Shop.Api.Services.Logs
{
    public interface ILogWriter : IDisposable
    {
        Task AddLog(LogModel logModel);
    }
}
