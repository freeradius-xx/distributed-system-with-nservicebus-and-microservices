using NServiceBus;

namespace Shared.Infrastructure
{
    public sealed class ServiceBus
    {
        public static IBus Bus { get; private set; }

        private static readonly object Lock = new object();

        public static void Initialize(string endpointName)
        {
            if (Bus != null) return;
            lock (Lock)
            {
                if (Bus != null) return;
                var config = new BusConfiguration();
                config.UsePersistence<InMemoryPersistence>();
                config.UseTransport<MsmqTransport>();
                config.EndpointName(endpointName);
                config.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Commands") && t.Name.EndsWith("Command"));
                config.Conventions().DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Events") && t.Name.EndsWith("Event"));
                config.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Messages") && t.Name.EndsWith("Message"));
                config.PurgeOnStartup(true);
                config.EnableInstallers();
                Bus = NServiceBus.Bus.Create(config).Start();
            }
        }
    }
}
