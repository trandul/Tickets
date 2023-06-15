using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITicketService
    {
        //Ticket GetById(int id);
        //IEnumerable<Ticket> GetAll();
        long Count();
        bool HasNewTickets();
    }
}
