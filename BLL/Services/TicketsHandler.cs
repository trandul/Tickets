using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketsHandler:ITicketsHandler
    {
        public delegate void TicketHandler();
        public event TicketHandler? Notify;

        private long _previousTicketsCount;
        private TicketService _ticketService;
        private bool _hasNewTickets;
        private ITimerService _timerService;
        private long _ticketsCount;
        public long TicketsCount { get => _ticketsCount; }
        public bool HasNewTickets { get=>_hasNewTickets; }
        private ILogger _logger;
        public TicketsHandler(IUoW uow,ILogger logger)
        {
            _logger = logger;
            _timerService = new TimerService();
            _timerService.Start();
            _timerService.Notify += SolveTicketsCount;
            _ticketService = new TicketService(uow);
            _previousTicketsCount = _ticketService.Count();
        }

        private void SolveTicketsCount()
        {
            _ticketsCount = _ticketService.Count();
            _logger.LogInformation($"{DateTime.Now} Произведён опрос базы данных");
            if (_ticketsCount > _previousTicketsCount)
            {
                _hasNewTickets = true;
                _logger.LogInformation($"{DateTime.Now} Добавлено {_ticketsCount-_previousTicketsCount} строк");
                _previousTicketsCount =_ticketsCount;
                Notify?.Invoke();
                
            }
            else
            {
                _hasNewTickets = false;
            }
        }

    }
}
