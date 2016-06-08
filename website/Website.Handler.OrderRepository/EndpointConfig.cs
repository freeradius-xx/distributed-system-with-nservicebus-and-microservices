
using System;
using Shared.Configuration;

namespace Website.Handler.OrderRepository
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "WEBSITE => ORDER REPOSITORY";

            config.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Messages") && t.Name.EndsWith("Message"));

            new MyConfiguration().DefaultBusConfiguration(config);
        }
    }
}
