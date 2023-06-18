using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TimerService : ITimerService
    {
        public delegate void TimerHandler();
        public event TimerHandler? Notify;

        private Task Timer;

        public TimerService()
        {

            Timer = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Notify?.Invoke();
                    Thread.Sleep(3000);
                }
            });

        }

    }
}
