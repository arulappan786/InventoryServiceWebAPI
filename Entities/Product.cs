using System.ComponentModel.DataAnnotations;

namespace InventoryServiceWebAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        [RegularExpression(@"^[0-9\-]+$")]        
        public int StockQuantity { get; set; }
    }
}
