using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tickets
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #region Commands
        private Command _dbListenerStartStop;
        public Command DbListenerStartStop
        {
            get
            {
                if (_dbListenerStartStop == null)
                {
                    _dbListenerStartStop = new Command(x =>
                    {
                        if (!_TicketsTracker.IsTrackingEnabled)
                        {
                            _TicketsTracker.StartTracking();
                            _ticketsTrackerEnabled = true;
                        }
                        else
                        {
                            _TicketsTracker.StopTracking();
                            _ticketsTrackerEnabled = false;
                        }
                        OnPropertyChanged("TicketsTrackerEnabled");
                    });

                }
                return _dbListenerStartStop;
            }
        }
        #endregion Commands
        private ITicketsTracker _TicketsTracker { get; set; }
        private bool _ticketsTrackerEnabled;
        public bool TicketsTrackerEnabled => _ticketsTrackerEnabled;



        private ITicketService _ticketService;
        public AppViewModel(IUoW uow, ILogger<MainWindow> logger)
        {
            _TicketsTracker = new TicketsTracker(uow, logger);
            _TicketsTracker.Notify += UpdateData;
        }

        private void UpdateData()
        {
            System.Media.SystemSounds.Asterisk.Play();
        }

    }
}
