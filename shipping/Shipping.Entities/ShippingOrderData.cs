using System;
using System.ComponentModel.DataAnnotations;
using Shared.ViewModels;

namespace Shipping.Entities
{
    public class ShippingOrderData
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public int ProductId { get; set; }
        public OrderState OrderState { get; set; }
        public string ResponsiblePerson { get; set; }
        public string EditedBy { get; set; }
        public DateTime EditedAt { get; set; }
    }
}
