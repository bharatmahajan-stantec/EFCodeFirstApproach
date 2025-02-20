using System;
using System.Collections.Generic;

namespace EFCodeFirst.DTO
{
    public class OrderDTO
    {
        public DateTime? OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
