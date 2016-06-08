using System;
using Shared.ViewModels;

namespace Shared.Messages
{
    public class AddNewOrderMessage
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
