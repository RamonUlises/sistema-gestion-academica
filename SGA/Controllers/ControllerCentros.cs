using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerCentros
    {
        public int ObtenerIdCentro(string centro)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT id_centro FROM centros WHERE centro = @centro";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@centro", centro);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32("id_centro");
                        } else
                        {
                            return -1;
                        }
                    }
                }
            } catch (Exception)
            {
                return -1;
            } finally
            {
                connection.CloseConnection();
            }
        }
        public string[] ObtenerCentros()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT centro FROM centros";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> centros = new List<string>();

                        while (reader.Read())
                        {
                            centros.Add(reader.GetString("centro"));
                        }

                        return centros.ToArray();
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
