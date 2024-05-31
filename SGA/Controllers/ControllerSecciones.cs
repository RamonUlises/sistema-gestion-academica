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
