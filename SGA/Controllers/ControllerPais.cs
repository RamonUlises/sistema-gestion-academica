using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerPais
    {
        public string[] ObtenerPaises() 
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT * FROM paises";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> paises = new List<string>();
                        while (reader.Read())
                        {
                            paises.Add(reader["pais"].ToString());
                        }
                        return paises.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public int ObtenerPaisPorNombre(string pais)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string paisSelect = pais;
                    string query = "SELECT id_pais FROM paises WHERE pais = '" + paisSelect + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["id_pais"].ToString());
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

        public string ObtenerNacionalidad(int pais)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT nacionalidad FROM nacionalidades WHERE id_pais = '" + pais + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader["nacionalidad"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "No se encontró la nacionalidad";
            }
            finally
            {
                connection.CloseConnection();
            }
        }
     }
}
