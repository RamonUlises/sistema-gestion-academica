using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerEtnias
    {
        public string[] ObtenerEtnias()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT etnia FROM etnias";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> etnias = new List<string>();
                        while (reader.Read())
                        {
                            etnias.Add(reader["etnia"].ToString());
                        }
                        return etnias.ToArray();
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
        public int ObtenerIdEtnia(string etnia)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    
                    string query = "SELECT id_etnia FROM etnias WHERE etnia = '" + etnia + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["id_etnia"].ToString());
                    }
                }
            } catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }
}
