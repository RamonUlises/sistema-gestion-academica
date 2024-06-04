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

        public int ObtenerIdDiscapacidad(string discapacidad)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_discapacidad FROM discapacidades WHERE discapacidad = '" + discapacidad + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["id_discapacidad"].ToString());
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

        public string ObtenerDiscapacidadPorId(int id)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT discapacidad FROM discapacidades WHERE id_discapacidad =  @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);


                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader["discapacidad"].ToString();
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
