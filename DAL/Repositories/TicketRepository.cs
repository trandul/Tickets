using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private ConnectionFactory _connectionFactory;
        public TicketRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public long Count()
        {
            using (var connection = _connectionFactory.Connection)
            {
                connection.Open();
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =  "SELECT SUM(row_count) " +
                                                "FROM sys.dm_db_partition_stats " +
                                                "WHERE object_id = OBJECT_ID('Tickets')";
                        var reader = command.ExecuteScalar();
                        return (long)reader;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                   // connection.Close();
                }
                
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            using (var connection = _connectionFactory.Connection)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Tickets]";
                    var reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        throw new Exception();
                    }
                    return null;
                }
            }
        }

        public Ticket GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
