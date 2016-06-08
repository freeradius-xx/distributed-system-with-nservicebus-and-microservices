using System;
using System.ComponentModel.DataAnnotations;
using Shared.ViewModels;

namespace Shared.OrderDb
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
