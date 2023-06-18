using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class TicketsTracker : ITicketsTracker
    {
        public delegate void TicketHandler();
        public event TicketHandler? Notify;

        private long _previousTicketsCount;
        private TicketService _ticketService;
        private ITimerService _timerService;
        private long _ticketsCount;
        private bool _isTrackingEnabled;
        public bool IsTrackingEnabled => _isTrackingEnabled;

        private ILogger _logger;
        public TicketsTracker(IUoW uow, ILogger logger)
        {
            _logger = logger;
            _timerService = new TimerService();
            _ticketService = new TicketService(uow, logger);
            try
            {
                _previousTicketsCount = (long)_ticketService.Count();
            }
            catch (Exception)
            {

                _logger.LogError($"{DateTime.Now} Произошла ошибка при получении количества записей в таблице");
            }
        }

        private void TrackTicketsCount()
        {
            try
            {
                _ticketsCount = (long)_ticketService.Count();
            }
            catch (Exception)
            {

                _logger.LogError($"{DateTime.Now} Произошла ошибка при получении количества записей в таблице");
            }
            _logger.LogInformation($"{DateTime.Now} Произведён опрос таблицы");
            if (_ticketsCount > _previousTicketsCount)
            {
                _logger.LogInformation($"{DateTime.Now} Добавлено {_ticketsCount - _previousTicketsCount} строк");
                _previousTicketsCount = _ticketsCount;
                Notify?.Invoke();

            }
        }

        public void StartTracking()
        {
            _timerService.Notify += TrackTicketsCount;
            _isTrackingEnabled = true;
            _logger.LogError($"{DateTime.Now} Запущен опрос таблицы на наличие новых записей");
        }

        public void StopTracking()
        {
            _timerService.Notify -= TrackTicketsCount;
            _isTrackingEnabled = false;
            _logger.LogError($"{DateTime.Now} Остановлен опрос таблицы на наличие новых записей");
        }
    }
}
