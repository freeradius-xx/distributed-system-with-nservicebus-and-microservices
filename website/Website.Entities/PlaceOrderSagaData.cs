using System;
using System.ComponentModel.DataAnnotations;
using NServiceBus.Saga;
using Shared.ViewModels;

namespace Website.Entities
{
    public class PlaceOrderSagaData : IContainSagaData
    {
        [Unique]
        [Key]
        public Guid OrderId { get; set; }
        public Guid Customerid { get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public OrderState OrderState { get; set; }


        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
    }
}
