using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerGrado
    {
        public int ObtenerIdGrado(string grado)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT id_grado FROM grados WHERE grado = @grado";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@grado", grado);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32("id_grado");
                        }

                        return 0;
                    }
                }
            } catch (Exception ex)
            {
                return 0;
            } finally
            {
                connection.CloseConnection();
            }
        }
        public string[] ObtenerGrados()
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT * FROM grados";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> grados = new List<string>();
                        while (reader.Read())
                        {
                            grados.Add(reader["grado"].ToString());
                        }

                        return grados.ToArray();
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
