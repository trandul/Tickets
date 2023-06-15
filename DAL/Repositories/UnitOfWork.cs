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
        private ConnectionFactory _connectionFactory;
        private ITicketRepository _ticketRepository;

        public UnitOfWork(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public ITicketRepository TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new TicketRepository(_connectionFactory);
                }
                return _ticketRepository;
            }
        }
    }
}
