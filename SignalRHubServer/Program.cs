using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SignalRHubServer.Program.Startup))]
namespace SignalRHubServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string url = "http://127.0.0.1:8088";
            string url = "http://localhost:8088";

            var app = WebApp.Start(url);
            Console.ReadKey();
        }

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
        }

        [HubName("TaskHub")]
        public class MyHub: Hub {
            public void Send(string name, string message)
            {
                Console.WriteLine(name + ": " + message);
                Clients.All.addMessage(name, message);
            }

            public void SendTask(dynamic request)
            {
                Console.WriteLine(request.ToString());
            }
        }
    }
}
