//using System;
//using NServiceBus;
//using Shared.Configuration;

//namespace Website.OrderSaga
//{
//    public class EndpointConfig : IConfigureThisEndpoint
//    {
//        public void Customize(BusConfiguration config)
//        {
//            if (Environment.UserInteractive)
//                Console.Title = "WEBSITE => SAGA";

//            config.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Commands") && t.Name.EndsWith("Command"));
//            config.Conventions().DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Events") && t.Name.EndsWith("Event"));
//            config.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Shared.Messages") && t.Name.EndsWith("Message"));


//            new MyConfiguration().DefaultBusConfiguration(config);
//        }
//    }
//}
