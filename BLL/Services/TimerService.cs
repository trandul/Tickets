using BLL.Interfaces;

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
