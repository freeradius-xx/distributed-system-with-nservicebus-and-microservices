
using System;
using Shared.Configuration;

namespace Shipping.Handler.OrderProcessor
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "SHIPPING ORDER";

            new MyConfiguration().DefaultBusConfiguration(config);
        }
    }
}
