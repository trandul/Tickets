using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            //TODO: убрать в конфиг
            string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Tickets;Trusted_Connection=True;";
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<IUoW, UnitOfWork>();
                    services.AddScoped<ITicketService, TicketService>();
                    services.AddScoped<ITimerService, TimerService>();
                    services.AddSingleton<ConnectionFactory>();
                })
                .Build();
            var app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
