using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Data
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int ImageId { get; set; }
        public virtual FileModel Image { get; set; }
    }


}
