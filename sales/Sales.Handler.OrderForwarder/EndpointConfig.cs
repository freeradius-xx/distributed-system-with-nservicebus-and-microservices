
using System;
using Shared.Configuration;

namespace Sales.Handler.OrderForwarder
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "ORDER FORWARDER";

            new MyConfiguration().DefaultBusConfiguration(config);
        }
    }
}
