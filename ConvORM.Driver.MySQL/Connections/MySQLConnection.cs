using ConvORM.Connections;
using ConvORM.Connections.Enum;
using ConvORM.Driver.MySQL.Connections.Drivers;
using ConvORM.Driver.MySQL.Connections.Parameters;
using System;

namespace ConvORM.Driver.MySQL.Connections
{
    public class MySQLConnection : Connection
    {
        public string ConnectionString { get; set; }

        public MySQLConnection()
        {
            Initialize();
        }

        public MySQLConnection(MySQLConnectionParameters mySQLConnectionParameters)
        {
            Initialize();
            ConnectionString = mySQLConnectionParameters.GetConnectionString();
        }

        public MySQLConnection(string connectionString)
        {
            Initialize();
            ConnectionString = connectionString;
        }

        public event EventHandler OpenConnection;

        public bool Open()
        {
            if (ConnectionDriver.Open(ConnectionString))
            {
                OpenConnection?.Invoke(this, EventArgs.Empty);
                return true;
            }

            return false;
        }

        #region Private methods

        private void Initialize()
        {
            ConnectionDriver = new MySQLConnectionDriver();
            OpenConnection += OnOpenConnection;
        }

        #endregion

        #region Events

        private void OnOpenConnection(object sender, EventArgs e)
        {
            if (EnableDebugLogger)
            {
                //Logger
            }

            State = EConnectionStates.Open;
            ConnectionPool.RegisterConnection(this);
        }

        #endregion
    }
}
