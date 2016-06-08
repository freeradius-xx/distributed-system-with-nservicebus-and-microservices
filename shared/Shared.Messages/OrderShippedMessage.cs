using System;
using Shared.ViewModels;

namespace Shared.Messages
{
    public class OrderShippedMessage
    {
        public Guid OrderId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
