using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerPeriodos
    {
        public int ObtenerIdPeriodo(string periodo)
        {
            DB_Connection conection = new DB_Connection();
            try
            {
                using (MySqlConnection con = conection.GetConnection())
                {
                    string query = "SELECT id_periodo FROM periodos WHERE periodo = @periodo";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@periodo", periodo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["id_periodo"]);
                        }
                        return -1;
                    }
                }
            } catch (Exception)
            {
                return -1;
            } finally
            {
                conection.CloseConnection();
            }
        }
        public string[] ObtenerPeriodos()
        {
            DB_Connection conection = new DB_Connection();
            try
            {
                using (MySqlConnection con = conection.GetConnection())
                {
                    string query = "SELECT * FROM periodos";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> periodos = new List<string>();
                        while (reader.Read())
                        {
                            periodos.Add(reader["periodo"].ToString());
                        }

                        return periodos.ToArray();
                    }
                }
            } catch (Exception ex)
            {
                return new string[] { "Error", ex.Message };
            } finally
            {
                conection.CloseConnection();
            }
        }
    }
}
