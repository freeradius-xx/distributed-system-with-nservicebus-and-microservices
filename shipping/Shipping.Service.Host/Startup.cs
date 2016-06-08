using System.Reflection;
using Microsoft.AspNet.SignalR;
using Owin;

namespace Shipping.Service.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var a = Assembly.LoadFrom("Shipping.Service.Hub.dll");

            app.MapHubs(
                new HubConfiguration
                {
                    EnableCrossDomain = true
                });
        }
    }
}
