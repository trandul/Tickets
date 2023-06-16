using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private ITicketsHandler _ticketsHandler { get; set; }

        public AppViewModel(IUoW uow, ILogger<MainWindow> logger)
        {
            _ticketsHandler = new TicketsHandler(uow, logger);
            _ticketsHandler.Notify += UpdateData;
        }
        
        private void UpdateData()
        {
            _ticketsCount = _ticketsHandler.TicketsCount;
            OnPropertyChanged("TicketsCount");
            System.Media.SystemSounds.Asterisk.Play();
        }
        
        //TODO: посмотреть-вспомнить, свойство не обновляется
        private long _ticketsCount;
        public long TicketsCount
        {
            get => _ticketsCount;
        }

    }
}
