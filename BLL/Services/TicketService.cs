using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        private IUoW _uow;
        public TicketService(IUoW uow)
        {
            _uow = uow;
        }

        public long Count()
        {
            return _uow.TicketRepository.Count();
        }

        public bool HasNewTickets()
        {
            throw new NotImplementedException();
        }
    }
}
