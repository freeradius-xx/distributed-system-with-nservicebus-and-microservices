
using System;
using Shared.Configuration;

namespace Sales.Handler.OrderProcessor
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "SALES";

            new MyConfiguration().DefaultBusConfiguration(config);
        }
    }
}
