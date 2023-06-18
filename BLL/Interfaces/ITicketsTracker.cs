using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.TicketsTracker;
using static BLL.Services.TimerService;

namespace BLL.Interfaces
{
    public interface ITicketsTracker
    {
        event TicketHandler Notify;
        void StartTracking();
        void StopTracking();
        bool IsTrackingEnabled { get; }
    }
}
