using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //TODO: шляпа, нам не нужна фабрика соединений
    public  class ConnectionFactory
    {
        private string _connectionString;
        private SqlConnection _connection;
        public SqlConnection Connection
        {
            get
            {

                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                return _connection;
            }
        }
        //TODO: перенести строку подключения в program
        public ConnectionFactory()
        {
            _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Tickets;Trusted_Connection=True;";
        }
    }
}
