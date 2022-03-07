using Shop.Api.Data;
using System;

namespace Shop.Api.DTO
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
