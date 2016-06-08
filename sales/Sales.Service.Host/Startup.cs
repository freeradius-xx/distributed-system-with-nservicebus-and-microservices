using System.Reflection;
using Microsoft.AspNet.SignalR;
using Owin;

namespace Sales.Service.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var a = Assembly.LoadFrom("Sales.Service.Hub.dll");

            app.MapHubs(
                new HubConfiguration
                {
                    EnableCrossDomain = true
                });
        }
    }
}
