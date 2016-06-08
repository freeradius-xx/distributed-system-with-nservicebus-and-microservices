using System;
using Shared.ViewModels;

namespace Shared.Events
{
    public class OrderSentToSalesEvent
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderState State { get; set; }
    }
}
