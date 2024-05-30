using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerModalidad
    {
        public string[] ObtenerModalidades()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT * FROM modalidades";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<string> modalidades = new List<string>();

                    while (reader.Read())
                    {
                        modalidades.Add(reader.GetString("modalidad"));
                    }

                    return modalidades.ToArray();
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
