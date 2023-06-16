using DAL.ConnectionSettings;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
