using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerLenguaMaterna
    {
        public string[] ObtenerLenguas()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT lengua FROM lenguas";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> lenguas = new List<string>();
                        while (reader.Read())
                        {
                            lenguas.Add(reader["lengua"].ToString());
                        }
                        return lenguas.ToArray();
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

        public int ObtenerIdLengua(string lengua)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using(MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_lengua FROM lenguas WHERE lengua = '" + lengua + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["id_lengua"].ToString());
                    }
                }
            } catch (Exception e)
            {
                return 0;
            } finally
            {
                connection.CloseConnection();
            }
        }
        public string ObtenerLenguaPorId(int id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT lengua FROM lenguas WHERE id_lengua = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["lengua"].ToString();
                        } else
                        {
                            return "Error";
                        }
                    }
                }
            } catch (Exception e)
            {
                return "Error";
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
