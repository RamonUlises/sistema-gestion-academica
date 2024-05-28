using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerDiscapacidad
    {
        public string[] ObtenerDiscapacidades()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT discapacidad FROM discapacidades";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> discapacidades = new List<string>();
                        while (reader.Read())
                        {
                            discapacidades.Add(reader["discapacidad"].ToString());
                        }
                        return discapacidades.ToArray();
                    }
                }
            } catch (Exception e)
            {
                return new string[] {};
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
