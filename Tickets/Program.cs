using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.ConnectionSettings;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                    services.AddLogging(configure => configure.AddProvider(new FileLoggerProvider(Directory.GetCurrentDirectory() + @"\log.txt")));
                    services.AddSingleton<App>();
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<IUoW, UnitOfWork>();
                    services.AddScoped<ITicketService, TicketService>();
                    services.AddScoped<ITimerService, TimerService>();
                    services.AddSingleton<ConnectionSettingsModel>(x=> new ConnectionSettingsModel(_connectionString));
                })
                .Build();
            var app = host.Services.GetService<App>();
            
            app?.Run();
            
        }
    }
}
