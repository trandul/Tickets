using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITicketRepository
    {
        //Ticket GetById(int id);
        //IEnumerable<Ticket> GetAll();
        long Count();
    }
}
