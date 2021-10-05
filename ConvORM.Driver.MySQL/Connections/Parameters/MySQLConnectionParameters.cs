using ConvORM.Connections;
using System;

namespace ConvORM.Driver.MySQL.Connections.Parameters
{
    /// <summary>
    /// MySQL/MariaDB connection parameter class
    /// </summary>
    public class MySQLConnectionParameters : IConnectionParameters
    {
        /// <summary>
        /// Server/Host address
        /// Default value: localhost
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Port of access
        /// Defalt value: 3306
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// Name of database
        /// Default value: Empty String
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// User to connect
        /// Default value: root
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// Password to connect
        /// Default value: Empty String
        /// </summary>
        public string Pwd { get; set; }

        public MySQLConnectionParameters()
        {
            Server = "localhost";
            Port = "3306";
            Database = "";
            Uid = "root";
            Pwd = "";
        }

        /// <summary>
        /// Validate and generate connection string
        /// </summary>
        /// <returns>The connection string</returns>
        public string GetConnectionString()
        {
            ValidateParameters();
            return $"Server={Server};{(ValidateParameter(Port, false) ? " Port=" + Port + ";" : "")} Database={Database}; Uid={Uid}; Pwd={Pwd}; SslMode=none";
        }

        private void ValidateParameters()
        {
            ValidateParameter(Server);
            ValidateParameter(Database);
            ValidateParameter(Uid);
            ValidateParameter(Pwd);

        }

        private bool ValidateParameter(string parameter, bool throwException = true)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                if (throwException)
                    throw new Exception();
         
                return false;
            }

            return true;            
        }
    }
}
