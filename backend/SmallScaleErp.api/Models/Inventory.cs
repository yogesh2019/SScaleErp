using System.ComponentModel.DataAnnotations;

namespace SmallScaleErp.api.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Category { get; set; }

        public int StockQty { get; set; }

        public string Warehouse { get; set; }
    }
}
