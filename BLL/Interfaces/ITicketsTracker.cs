using static BLL.Services.TicketsTracker;

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
