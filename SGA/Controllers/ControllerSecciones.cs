using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerSecciones
    {
        public string ObtenerSeccionPorId(int id)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT seccion FROM secciones WHERE id_seccion = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString("seccion");
                        }

                        return null;
                    }
                }
            } catch (Exception ex)
            {
                return null;
            } finally
            {
                connection.CloseConnection();
            }
        }
        public int ObtenerIdSeccion(string seccion)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT id_seccion FROM secciones WHERE seccion = @seccion";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@seccion", seccion);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32("id_seccion");
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
        public string[] ObtenerSecciones()
        {
            DB_Connection conection = new DB_Connection();

            try
            {
                 using (MySqlConnection con = conection.GetConnection())
                {
                    string query = "SELECT * FROM secciones";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> secciones = new List<string>();
                        while (reader.Read())
                        {
                            secciones.Add(reader["seccion"].ToString());
                        }

                        return secciones.ToArray();
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
