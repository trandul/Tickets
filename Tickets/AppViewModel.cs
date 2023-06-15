using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
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

        public TicketsHandler TicketsHandler { get; set; }

        public AppViewModel(IUoW uow)
        {
            TicketsHandler = new TicketsHandler(uow);
            var ticketService = new TicketService(uow);
           // _ticketsCount = ticketService.Count();
        }
        //TODO: посмотреть-вспомнить, свойство не обновляется
        private long _ticketsCount;
        public long TicketsCount
        {
            get => TicketsHandler.TicketsCount;
        }

        private bool _appModel;
        public bool AppModel
        {
            get => _appModel;
        }
    }
}
