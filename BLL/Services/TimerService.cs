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
        private bool _isRunning;
        public delegate void TimerHandler();
        public event TimerHandler? Notify;

        public void Start()
        {
            _isRunning = true;
            Task.Factory.StartNew(() =>
            {
                while (_isRunning)
                {
                    Notify?.Invoke();
                    Thread.Sleep(3000);
                }
            });
        }

        public void Stop()
        {
            _isRunning=false;
        }

        private void Timer()
        {

        }
    }
}
