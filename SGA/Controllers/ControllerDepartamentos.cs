using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerDepartamentos
    {
        public string[] ObtenerDepartamentos(int pais)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT departamento FROM departamentos WHERE id_pais = '" + pais + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> departamentos = new List<string>();
                        while (reader.Read())
                        {
                            departamentos.Add(reader["departamento"].ToString());
                        }
                        return departamentos.ToArray();
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

        public int ObtenerIdDepartamento(string departamento)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_departamento FROM departamentos WHERE departamento = '" + departamento + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return Convert.ToInt32(reader["id_departamento"]);
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
    }
}
