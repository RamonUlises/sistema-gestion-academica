using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerTurnos
    {
        public string ObtenerTurnoPorId(int id)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT turno FROM turnos WHERE id_turno = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString("turno");
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
        public int ObtenerIdTurno(string turno)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT id_turno FROM turnos WHERE turno = @turno";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@turno", turno);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32("id_turno");
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
        public string[] ObtenerTurnos()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection conn = connection.GetConnection())
                {

                    string query = "SELECT * FROM turnos";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> turnos = new List<string>();
                        while (reader.Read())
                        {
                            turnos.Add(reader["turno"].ToString());
                        }

                        return turnos.ToArray();
                    }                 
                }

            } catch (Exception ex)
            {
                return new string[] { ex.Message };
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
