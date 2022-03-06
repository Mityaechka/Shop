using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Data
{
    public class FileModel
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Path { get; set; }
    }
}
