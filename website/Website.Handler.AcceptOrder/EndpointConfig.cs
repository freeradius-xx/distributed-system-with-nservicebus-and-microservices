
using System;
using Shared.Configuration;

namespace Website.Handler.AcceptOrder
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "WEBSITE => ACCEPT ORDER";

            new MyConfiguration().DefaultBusConfiguration(config);
        }
    }
}
