using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Data
{
    public class OrderLog
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int LogId { get; set; }
        public virtual Log Log { get; set; }

    }
}
