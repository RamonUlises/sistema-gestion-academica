using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerMunicipios
    {
        public string[] ObtenerMunicipios(int departamento)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT municipio FROM municipios WHERE id_departamento = '" + departamento + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> municipios = new List<string>();
                        while (reader.Read())
                        {
                            municipios.Add(reader["municipio"].ToString());
                        }
                        return municipios.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return new string[] {};
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public int ObtenerIdMunicipio(string municipio)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_municipio FROM municipios WHERE municipio = @municipio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@municipio", municipio);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return Convert.ToInt32(reader["id_municipio"]);
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public string ObtenerMunicipioPorId(int id_municipio)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT municipio FROM municipios WHERE id_municipio = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn); 
                    cmd.Parameters.AddWithValue("@id", id_municipio);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader["municipio"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                connection.CloseConnection();
            }
        }

    }
}
