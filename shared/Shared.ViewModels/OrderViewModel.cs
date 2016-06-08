using System;

namespace Shared.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
