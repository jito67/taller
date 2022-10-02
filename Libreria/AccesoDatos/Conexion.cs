using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace AccesoDatos
{
    public abstract class Conexion
    {
        private readonly string ConnectionString;
        public Conexion()
        {
            ConnectionString = "Data Source = 54.94.32.11; Database = admin_iacc;" +
                "Uid=Supervisor;password=Supervisor;integrated security=true";
        }
        protected MySqlConnection Conectarse()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}

