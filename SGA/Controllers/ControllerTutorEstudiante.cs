using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SGA.Controllers
{
    class ControllerTutorEstudiante
    {
        public int AgregarTutor (Clases.ClassEstudiantes tutor)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string[] nombresYApellidos = tutor.NombresTutor.Split(' ');
                    string nombres = nombresYApellidos[0] + " " + (nombresYApellidos.Length > 1 ? nombresYApellidos[1] : "");
                    string apellidos = (nombresYApellidos.Length > 2 ? nombresYApellidos[2] : "") + " " + (nombresYApellidos.Length > 3 ? nombresYApellidos[3] : "");

                    // La consulta SQL con parámetros
                    string query = "INSERT INTO tutores_x_estudiantes (nombres, apellidos, cedula, telefono) VALUES (@nombres, @apellidos, @cedula, @telefono); SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombres", nombres);
                    cmd.Parameters.AddWithValue("@apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@cedula", tutor.CedulaTutor);
                    cmd.Parameters.AddWithValue("@telefono", tutor.TelefonoTutor);

                    // Ejecuta la consulta y obtiene el ID generado
                    int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                    return idGenerado;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }
        }


        public bool ValidarCedulaTutor(string cedula, string nombresTutor)
        {
            DB_Connection connection = new DB_Connection();

            // Manejo seguro de nombres y apellidos
            string[] nombresYApellidos = nombresTutor.Split(' ');
            string nombres = nombresYApellidos.Length > 1 ? nombresYApellidos[0] + " " + nombresYApellidos[1] : nombresYApellidos[0];
            string apellidos = nombresYApellidos.Length > 3 ? nombresYApellidos[2] + " " + nombresYApellidos[3] : (nombresYApellidos.Length > 2 ? nombresYApellidos[2] : "");

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    // Consulta SQL optimizada
                    string query = "SELECT nombres, apellidos FROM tutores_x_estudiantes WHERE cedula = @cedula";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dbNombres = reader["nombres"].ToString();
                            string dbApellidos = reader["apellidos"].ToString();

                            // Comparación de nombres y apellidos
                            if (dbNombres != nombres || dbApellidos != apellidos)
                            {
                                return true; // Existe la cédula con diferentes nombres y apellidos
                            }
                        }

                        return false; // No se encontró la cédula o coincide con los nombres y apellidos proporcionados
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de excepciones
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
        public int ValidarTutor (Clases.ClassEstudiantes tutor)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    bool result = ValidarCedulaTutor(tutor.CedulaTutor, tutor.NombresTutor);

                    if(result)
                    {
                        return 0;
                    }

                    string query = "SELECT COUNT(*) FROM tutores_x_estudiantes WHERE cedula = @cedula";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cedula", tutor.CedulaTutor);


                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return BuscarTutor(tutor.CedulaTutor);
                    }


                    int idTutor = AgregarTutor(tutor);
                    return idTutor;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }

        }
        public int BuscarTutor (string cedula)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_tutor_x_estudiante FROM tutores_x_estudiantes WHERE cedula = @cedula";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return int.Parse(reader["id_tutor_x_estudiante"].ToString());
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception e)
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
