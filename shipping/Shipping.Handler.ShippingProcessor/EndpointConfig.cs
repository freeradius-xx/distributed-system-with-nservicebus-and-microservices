
using System;
using Shared.Configuration;

namespace Shipping.Handler.ShippingProcessor
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "SHIPPING PROCESSOR";

            new MyConfiguration().DefaultBusConfiguration(config);
        }
    }
}
