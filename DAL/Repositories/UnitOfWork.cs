using DAL.ConnectionSettings;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUoW
    {
        private ConnectionSettingsModel _connectionSettings;
        private ITicketRepository _ticketRepository;

        public UnitOfWork(ConnectionSettingsModel connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }
        public ITicketRepository TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new TicketRepository(_connectionSettings);
                }
                return _ticketRepository;
            }
        }
    }
}
