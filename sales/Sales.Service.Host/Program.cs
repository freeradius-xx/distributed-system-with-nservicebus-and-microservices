using System;
using Microsoft.AspNet.SignalR;
using Sales.Service.Hub;

namespace Sales.Service.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:1111"))
            {
                Console.WriteLine("Hubs running...");
                var context = GlobalHost.ConnectionManager.GetHubContext<SalesHub>();

                Console.WriteLine("Do you want to send a test message SALES to clients? Press ENTER...");
                Console.ReadLine();
                context.Clients.All.test("This is a test message from the hosting service...");

                Console.WriteLine("Press <Enter> to exit...");

                Console.Read();
            }
        }
    }
}
