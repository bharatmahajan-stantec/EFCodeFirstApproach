using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFCodeFirst.EntityClasses
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; } = null!;
        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; } = null!;
    }
}
