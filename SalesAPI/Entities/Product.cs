using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAPI.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public double InputPrice { get; set; }
        public double OutputPrice { get; set; }
        public int Quantity { get; set; }

        public Guid CategoryId {  get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
