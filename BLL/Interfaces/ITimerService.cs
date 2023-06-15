using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.TimerService;

namespace BLL.Interfaces
{
    public interface ITimerService
    {
        event TimerHandler Notify;
        void Start();
        void Stop();
    }
}
