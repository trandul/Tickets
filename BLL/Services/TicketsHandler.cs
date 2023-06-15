using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketsHandler
    {
        private long _previousTicketsCount;
        private TicketService _ticketService;
        private bool _hasNewTickets;
        private ITimerService _timerService;
        private long _ticketsCount;
        public long TicketsCount { get => _ticketsCount; }
        public bool HasNewTickets { get=>_hasNewTickets; }

        public TicketsHandler(IUoW uow)
        {
            _timerService = new TimerService();
            _timerService.Start();
            _timerService.Notify += SolveTicketsCount;
            _ticketService = new TicketService(uow);
            _previousTicketsCount = _ticketService.Count();
        }

        private void SolveTicketsCount()
        {
            _ticketsCount = _ticketService.Count();
            if (_ticketsCount > _previousTicketsCount)
            {
                _hasNewTickets = true;
            }
            else
            {
                _hasNewTickets = false;
            }
        }

    }
}
