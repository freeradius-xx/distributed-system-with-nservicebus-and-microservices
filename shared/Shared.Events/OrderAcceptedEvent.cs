using System;
using Shared.ViewModels;

namespace Shared.Events
{
    public class OrderAcceptedEvent
    {
        public Guid OrderId { get; set; }
        public OrderState State { get; set; }
    }
}
