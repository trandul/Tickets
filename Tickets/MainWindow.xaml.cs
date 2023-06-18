using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;

namespace Tickets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(IUoW uow, ILogger<MainWindow> logger)
        {
            InitializeComponent();
            logger.LogInformation($"{DateTime.Now} Main Window initialized");
            this.DataContext = new AppViewModel(uow, logger);
        }
    }
}
