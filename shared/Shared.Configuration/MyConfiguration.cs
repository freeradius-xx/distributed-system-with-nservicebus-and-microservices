using System;
using NServiceBus;

namespace Shared.Configuration
{
    public class MyConfiguration
    {
        public void DefaultBusConfiguration(BusConfiguration config)
        {
            config.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Commands") && t.Name.EndsWith("Command"));
            config.Conventions().DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Events") && t.Name.EndsWith("Event"));
            config.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Messages") && t.Name.EndsWith("Message"));
            config.UsePersistence<InMemoryPersistence>();
        }
    }
}
