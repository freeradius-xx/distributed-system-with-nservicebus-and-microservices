using System;
using Shared.ViewModels;

namespace Shared.Commands
{
    public class ShippOrderCommand
    {
        public Guid OrderId { get; set; }
        public OrderState State { get; set; }
    }
}
