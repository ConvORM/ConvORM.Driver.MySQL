using ConvORM.Connections.Drivers;
using ConvORM.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConvORM.Driver.MySQL.Connections.Drivers
{
    public class MySQLConnectionDriver : IConnectionDriver
    {
        private MySqlConnection _connection;

        public bool Open(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);

            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteCommand(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sql, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public IList ExecuteQuery(string sql, Type entityType)
        {
            throw new NotImplementedException();
        }

        public Entity ExecuteScalarQuery(string sql, Type entityType)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedId()
        {
            throw new NotImplementedException();
        }
    }
}
