using static BLL.Services.TimerService;

namespace BLL.Interfaces
{
    public interface ITimerService
    {
        event TimerHandler Notify;
    }
}
