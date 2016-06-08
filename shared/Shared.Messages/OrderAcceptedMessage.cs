using System;
using Shared.ViewModels;

namespace Shared.Messages
{
    public class OrderAcceptedMessage
    {
        public Guid OrderId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
