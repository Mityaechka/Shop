using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Data
{
    public class Log
    {
        public int Id { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
        public LogLevel Level { get; set; }

        public DateTime Date { get; set; }
    }
}
