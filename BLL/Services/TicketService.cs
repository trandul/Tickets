using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        private IUoW _uow;
        private ILogger _logger;
        public TicketService(IUoW uow, ILogger logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public long? Count()
        {
            try
            {

                return _uow.TicketRepository.Count();

            }
            catch (Exception)
            {

                _logger.LogError($"{DateTime.Now} Ошибка работы с базой данных");
                return null;
            }
        }
    }
}
