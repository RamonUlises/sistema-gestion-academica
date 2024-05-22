using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Connection
{
    internal class DB_Connection
    {
        private MySqlConnection conexion;
        private string server = "localhost";
        private string database = "sistema_gestion_academica";
        private string user = "root";
        private string password = "57810634rrr";
        private string cadenaConnection;

        public DB_Connection()
        {
            cadenaConnection = "Database=" + database + "; Data Source=" + server + "; User Id=" + user + "; Password=" + password + ";";
        }

        public MySqlConnection GetConnection()
        {
            if(conexion == null)
            {
                conexion = new MySqlConnection(cadenaConnection);
                conexion.Open();
            }

            return conexion;
        }
    }
}
