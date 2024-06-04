using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerSexos
    {
        public string ObtenerSexo(int id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT sexo FROM sexos WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@id", id);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["sexo"].ToString();
                        } else
                        {
                            return "Error";
                        }
                    }
                }
            } catch (Exception ex)
            {
                return "Error";
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
