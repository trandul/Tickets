using System.Windows;

namespace Tickets
{
    public class App : Application
    {
        readonly MainWindow window;
        public App(MainWindow window)
        {
            this.window = window;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            window.Show();
            base.OnStartup(e);
        }
    }
}
