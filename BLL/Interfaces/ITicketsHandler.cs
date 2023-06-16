using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.TicketsHandler;
using static BLL.Services.TimerService;

namespace BLL.Interfaces
{
    public interface ITicketsHandler
    {
        event TicketHandler Notify;
        long TicketsCount { get; }
        bool HasNewTickets { get; }
    }
}
