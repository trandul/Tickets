using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class FileLogger : ILogger, IDisposable
    {
        private string _path;
        static object _lock = new object();

        public FileLogger(string path)
        {
            _path = path;
        }

        public IDisposable? BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                File.AppendAllText(_path, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}
