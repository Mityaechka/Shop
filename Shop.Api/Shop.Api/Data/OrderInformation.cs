using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Data
{
    public class OrderInformation
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(16)]
        public string CardNumber { get; set; }
    }
}
