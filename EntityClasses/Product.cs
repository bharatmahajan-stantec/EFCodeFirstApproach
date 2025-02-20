using System.Text.Json.Serialization;

namespace EFCodeFirst.EntityClasses
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Color { get; set; } // New property
        public decimal Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
