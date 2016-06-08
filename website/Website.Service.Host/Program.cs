using System;
using Microsoft.AspNet.SignalR;
using Website.Service.Hub;

namespace Website.Service.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:3333"))
            {
                Console.Title = "WEBSITE => SignalR HOST";

                Console.WriteLine("Hubs running...");
                var context = GlobalHost.ConnectionManager.GetHubContext<WebsiteHub>();

                Console.WriteLine("Do you want to send a test message to WEBSITE clients? Press ENTER...");
                Console.ReadLine();
                context.Clients.All.test("This is a test message from the hosting service...");

                Console.WriteLine("Press <Enter> to exit...");
                Console.Read();
            }
        }
    }
}
