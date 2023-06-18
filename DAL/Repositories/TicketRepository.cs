﻿using DAL.ConnectionSettings;
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
        private ConnectionSettingsModel _connectionSettings;
        public TicketRepository(ConnectionSettingsModel connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        public long Count()
        {
            try
            {


                using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "SELECT SUM(row_count) " +
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
                        connection.Close();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public IEnumerable<Ticket> GetAll()
        //{
        //    using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
        //    {
        //        using (var command = connection.CreateCommand())
        //        {
        //            command.CommandText = "SELECT * FROM [Tickets]";
        //            var reader = command.ExecuteReader();
        //            if (!reader.Read())
        //            {
        //                throw new Exception();
        //            }
        //            return null;
        //        }
        //    }
        //}

        //public Ticket GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
