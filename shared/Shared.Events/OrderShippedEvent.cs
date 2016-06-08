using System;
using Shared.ViewModels;

namespace Shared.Events
{
    public class OrderShippedEvent
    {
        public Guid OrderId { get; set; }
        public OrderState State { get; set; }
    }
}
