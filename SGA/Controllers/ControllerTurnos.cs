using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerTurnos
    {
        public string[] ObtenerTurnos()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection conn = connection.GetConnection())
                {

                    string query = "SELECT * FROM turnos";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> turnos = new List<string>();
                        while (reader.Read())
                        {
                            turnos.Add(reader["turno"].ToString());
                        }

                        return turnos.ToArray();
                    }                 
                }

            } catch (Exception ex)
            {
                return new string[] { ex.Message };
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
